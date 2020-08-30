using System;
using System.Collections.Generic;

using System.Data;
using System.Linq;
using AutoMapper.Configuration;
using GovLookup.DataAccess.RepositoryContract;
using GovLookup.Models;
using GovLookup.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using RefreshData.DataModel;

namespace GovLookup.DataAccess.Repository
{
    public class GovLookupRepository : BaseRepository, IGovLookupRepository

    {
        public  GovLookupDbContext GovLookupDbContext { get; set; }

        public GovLookupRepository()
        { 
        }
        
        #region legislators
        public List<Legislator> GetAllLegislators()
        {

            var results = GovLookupDbContext.SqlQuery<Legislator>("usp_GetLegislatorsAll", null, CommandType.StoredProcedure);

            return results.ToList();
        }

        public Legislator GetLegislatorById(string id)
        {
            var inputParameters = new Dictionary<string, object>
            {
                { "@Id", id }

            };

            var result = GovLookupDbContext.SqlQuery<Legislator>("usp_GetLegislatorById", inputParameters, CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }
        public List<Legislator> GetLegislatorsByName(string name)
        {
            var inputParameters = new Dictionary<string, object>
            {
                { "@Name", name }

            };

            var results = GovLookupDbContext.SqlQuery<Legislator>("usp_GetLegislatorsByName", inputParameters, CommandType.StoredProcedure);

            return results.ToList();
        }
        public List<Legislator> GetLegislatorsByZipcode(string zipcode)
        {
            var inputParameters = new Dictionary<string, object>
            {
                { "@Zipcode", zipcode }

            };

            var results = GovLookupDbContext.SqlQuery<Legislator>("usp_GetLegislatorsByZipcode", inputParameters, CommandType.StoredProcedure);

            return results.ToList();
        }
        public List<Legislator> GetLegislatorsByLngLat(string lng, string lat)
        {
            var inputParameters = new Dictionary<string, object>
            {
                { "@Lng", lng },
                { "@Lat", lat } 

            };

            var results = GovLookupDbContext.SqlQuery<Legislator>("usp_GetLegislatorsByLngLat", inputParameters, CommandType.StoredProcedure);

            return results.ToList();
        }

        public List<IndustryFinance> GetLegislatorIndustryFinance(string id)
        {
            var inputParameters = new Dictionary<string, object>
            {
                { "@Id", id}

            };

            var results = GovLookupDbContext.SqlQuery<IndustryFinance>("usp_GetLegislatorIndustryFinance", inputParameters, CommandType.StoredProcedure);

            return results.ToList();
        }

        public List<Rating> GetLegislatorRatings(string id)
        {
            var inputParameters = new Dictionary<string, object>
            {
                { "@Id", id}

            };

            var results = GovLookupDbContext.SqlQuery<Rating>("usp_GetLegislatorRatings", inputParameters, CommandType.StoredProcedure);

            return results.ToList();
        }
        public List<KeyVote> GetLegislatorKeyVotes(string id)
        {
            var inputParameters = new Dictionary<string, object>
            {
                { "@Id", id}

            };

            var results = GovLookupDbContext.SqlQuery<KeyVote>("usp_GetLegislatorKeyVotes", inputParameters, CommandType.StoredProcedure);

            return results.ToList();
        }
        public List<Bill> GetLegislatorBills(string id)
        {
            var inputParameters = new Dictionary<string, object>
            {
                    { "@Id", id}
             };

            var results = GovLookupDbContext.SqlQuery<Bill>("usp_GetLegislatorBills", inputParameters, CommandType.StoredProcedure);

            return results.ToList();
        }

        public List<Committee> GetLegislatorCommittees(string id)
        {
            var inputParameters = new Dictionary<string, object>
            {
                    { "@Id", id}
             };

            var results = GovLookupDbContext.SqlQuery<Committee>("usp_GetLegislatorCommittees", inputParameters, CommandType.StoredProcedure);

            return results.ToList();
        }

        #endregion

        #region cabinet

        public List<Cabinet> GetAllCabinet()
        {

            var results = GovLookupDbContext.SqlQuery<Cabinet>("usp_GetCabinetAll", null, CommandType.StoredProcedure);

            return results.ToList();
        }


        public Cabinet GetCabinetById(string id)
        {
            var inputParameters = new Dictionary<string, object>
            {
                { "@Id", id }

            };

            var result = GovLookupDbContext.SqlQuery<Cabinet>("usp_GetCabinetById", inputParameters, CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

       

         public List<School> GetCabinetEducation(string id)
        {
            var inputParameters = new Dictionary<string, object>
            {
                { "@Id", id }

            };

            var results = GovLookupDbContext.SqlQuery<School>("usp_GetCabinetEducation", inputParameters, CommandType.StoredProcedure);

            return results.ToList();
        }

        public List<JobPosition> GetCabinetJobHistory(string id)
        {
            var inputParameters = new Dictionary<string, object>
            {
                { "@Id", id }

            };

            var results = GovLookupDbContext.SqlQuery<JobPosition>("usp_GetCabinetJobHistory", inputParameters, CommandType.StoredProcedure);

            return results.ToList();
        }

        #endregion

        #region judiciary

        public List<Judiciary> GetAllJudiciary()
        {

            var results = GovLookupDbContext.SqlQuery<Judiciary>("usp_GetJudiciaryAll", null, CommandType.StoredProcedure);

            return results.ToList();
        }
      
        public Judiciary GetJudiciaryById(string id)
        {
            var inputParameters = new Dictionary<string, object>
            {
                { "@Id", id }
            };

            var result = GovLookupDbContext.SqlQuery<Judiciary>("usp_GetJudiciaryById", inputParameters, CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }
            
    

       
        public List<KeyDecisions>GetJudiciaryKeyDecisions(string id)
        {
            var inputParameters = new Dictionary<string, object>
            {
                { "@Id", id}

            };

            var results = GovLookupDbContext.SqlQuery<KeyDecisions>("usp_GetJudiciaryKeyDecisions", inputParameters, CommandType.StoredProcedure);

            return results.ToList();
        }
        public List<KeyDecisionsOpinions> GetJudiciaryKeyDecisionsOpinions(string id)
        {
            var inputParameters = new Dictionary<string, object>
            {
                { "@Id", id}

            };

            var results = GovLookupDbContext.SqlQuery<KeyDecisionsOpinions>("usp_GetJudiciaryKeyDecisionsOpinions", inputParameters, CommandType.StoredProcedure);

            return results.ToList();
        }

       
        public List<RollCallDecision> GetJudiciaryRollCallDecision(string docket)
        {
            var inputParameters = new Dictionary<string, object>
            {
                { "@Docket", docket}

            };

            var results = GovLookupDbContext.SqlQuery<RollCallDecision>("usp_GetJudiciaryRollCallDecision", inputParameters, CommandType.StoredProcedure);

            return results.ToList();
        }

        #endregion

        #region bills

        public List<CurrentBills> GetCurrentBills()
        {
            var results = GovLookupDbContext.SqlQuery<CurrentBills>("usp_GetCurrentBills", null, CommandType.StoredProcedure);

            return results.ToList();
        }

        #endregion

    }
}