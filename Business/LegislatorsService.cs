﻿using System;
using GovLookup.Models;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net;
using GovLookup.Business.Contract;
using GovLookup.DataAccess.RepositoryContract;
using System.Collections.Generic;
using GovLookupWebapi.Models;
using AutoMapper;
using Newtonsoft.Json;

namespace GovLookup.Business.Implementation
{
    public class LegislatorsService : ILegislatorsService
    {

        public IGovLookupRepository GovLookupRepository { get; set; }
        public IMapper mapper { get; set; }

        private string _geocodeUrl = "https://geocoding.geo.census.gov/geocoder/locations/onelineaddress";

        #region legislatorFind
        public IEnumerable<LegislatorSummaryDto> GetLegislators(string searchValue)
        {

            List<Legislator> legislatorsFromDb;

            if (string.IsNullOrWhiteSpace(searchValue))
            {
                legislatorsFromDb = GovLookupRepository.GetAllLegislators();
            }
            else
            {
                legislatorsFromDb = GetLegislatorsBySearchValue(searchValue);
            }
            return mapper.Map<IEnumerable<LegislatorSummaryDto>>(legislatorsFromDb);

        }
        public LegislatorDetailDto GetLegislatorById(string id)
        {
            var legislatorFromDb = GovLookupRepository.GetLegislatorById(id);
            AddLegislatorData(legislatorFromDb);
            return mapper.Map<LegislatorDetailDto>(legislatorFromDb);
        }


        // serach value could be a name, address or zipcode.
        public List<Legislator> GetLegislatorsBySearchValue(string searchValue)
        {

            if (IsValidZip(ref searchValue))
            {
                return GovLookupRepository.GetLegislatorsByZipcode(searchValue);
            }
            else
            {
                var legislatorsFromDb = GetLegislatorsByAddress(searchValue);

                if (legislatorsFromDb != null)
                {
                    return legislatorsFromDb;
                }
                else
                {
                    return GovLookupRepository.GetLegislatorsByName(searchValue);
                }
            }

        }

        private void AddLegislatorData(Legislator legislator)
        {
            if (legislator == null) return;

            legislator.Ratings = GovLookupRepository.GetLegislatorRatings(legislator.Id);
            legislator.KeyVotes = GovLookupRepository.GetLegislatorKeyVotes(legislator.Id);
            legislator.Bills = GovLookupRepository.GetLegislatorBills(legislator.Id);
            legislator.Committees = GovLookupRepository.GetLegislatorCommittees(legislator.Id);
            legislator.IndustryFinance = GovLookupRepository.GetLegislatorIndustryFinance(legislator.Id);
            legislator.IndustryFinanceChart = MapToPieChart(GovLookupRepository.GetLegislatorIndustryFinance(legislator.Id));
            legislator.IndustryFinanceChartOptions = GetIndustryFinanceChartOptions();


        }
        #endregion
        #region legislatorAddress

        public List<Legislator> GetLegislatorsByAddress(string searchValue)
        {

            AddressDetails ar = GetAddressDetails(searchValue);
            if (ar != null)
            {
                if (ar.result.addressMatches.Count == 0) return null;
                AddressCorrdinates ac = GetAddressCoordinates(ar);
                if (ac != null)
                {
                    return GovLookupRepository.GetLegislatorsByLngLat(ac.longitude, ac.latitude);
                }
            }
            return null;
        }

            

        public AddressDetails GetAddressDetails(string searchValue)
        {
            using (var client = new HttpClient())
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                client.BaseAddress = new Uri(_geocodeUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync("?address=" + searchValue + "&benchmark=9&format=json").Result;
                if (response.IsSuccessStatusCode)
                {
                    string responseString = response.Content.ReadAsStringAsync().Result;
                    if (responseString.ToLower().Contains("unavailable")) return null;

                    AddressDetails data = JsonConvert.DeserializeObject<AddressDetails>(responseString);
                    return data;
                }
            }
            return null;
        }

        public AddressCorrdinates GetAddressCoordinates(AddressDetails ar)
        {
            AddressCorrdinates ac = new AddressCorrdinates();
            if (ar != null)
            {
                ac.latitude = ar.result.addressMatches[0].coordinates.y.ToString();
                ac.longitude = ar.result.addressMatches[0].coordinates.x.ToString();
                return ac;
            }
            return null;

        }

        private bool IsValidZip(ref string val)
        {
            bool isNumeric = false;

            if ((val.Length >= 5) && (val.Length <= 10))
            {
                string zip = val.Substring(0, 5);
                int n;
                isNumeric = int.TryParse(zip, out n);
                if (isNumeric) val = zip;

            }
            return isNumeric;
        }

        #endregion

        #region legislatorIndustry

        private PieChartOptions GetIndustryFinanceChartOptions()
        {
            var options = new PieChartOptions();
            options.title = new PieChartTitle();
            options.title.text = "Industry Finance";
            options.title.display = true;
            options.title.fontsize = 22;
            options.legend = new PieChartLegend();
            options.legend.position = "bottom";
            return options;

        }

        public PieChart MapToPieChart(List<IndustryFinance> listIndustryFinance)
        {
            var chart = new PieChart();
            chart.datasets = new List<PieChartDataset>();
            chart.labels = new List<string>();
            var pcd = new PieChartDataset();
            pcd.data = new List<int>();
            pcd.backgroundColor = new List<string>();
            pcd.hoverBackgroundColor = new List<string>();

            foreach (IndustryFinance detail in listIndustryFinance)
            {
                pcd.data.Add(detail.Total);
                pcd.backgroundColor.Add(detail.ChartColor);
                pcd.hoverBackgroundColor.Add(detail.HoverColor);
                chart.labels.Add(detail.IndustryName);
            }
            chart.datasets.Add(pcd);
            return chart;
        }

        #endregion
    }
}