using System;
using System.Collections.Generic;

using System.Data;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<List<Legislator>> GetAllLegislators()
        {

            var results = await GovLookupDbContext.SqlQuery<Legislator>("usp_GetLegislatorsAll", null, CommandType.StoredProcedure);

            return results.ToList();
        }

        public async Task<Legislator> GetLegislatorById(string id)
        {
            var inputParameters = new Dictionary<string, object>
            {
                { "@Id", id }

            };

            var result = await GovLookupDbContext.SqlQuery<Legislator>("usp_GetLegislatorById", inputParameters, CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }
        public async Task<List<Legislator>> GetLegislatorsByName(string name)
        {
            var inputParameters = new Dictionary<string, object>
            {
                { "@Name", name }

            };

            var results = await GovLookupDbContext.SqlQuery<Legislator>("usp_GetLegislatorsByName", inputParameters, CommandType.StoredProcedure);

            return results.ToList();
        }
        public async Task<List<Legislator>> GetLegislatorsByZipcode(string zipcode)
        {
            var inputParameters = new Dictionary<string, object>
            {
                { "@Zipcode", zipcode }

            };

            var results = await GovLookupDbContext.SqlQuery<Legislator>("usp_GetLegislatorsByZipcode", inputParameters, CommandType.StoredProcedure);

            return results.ToList();
        }
        public async Task<List<Legislator>> GetLegislatorsByLngLat(string lng, string lat)
        {
            var inputParameters = new Dictionary<string, object>
            {
                { "@Lng", lng },
                { "@Lat", lat } 

            };

            var results = await  GovLookupDbContext.SqlQuery<Legislator>("usp_GetLegislatorsByLngLat", inputParameters, CommandType.StoredProcedure);

            return results.ToList();
        }

        public async Task<List<IndustryFinance>> GetLegislatorIndustryFinance(string id)
        {
            var inputParameters = new Dictionary<string, object>
            {
                { "@Id", id}

            };

            var results = await GovLookupDbContext.SqlQuery<IndustryFinance>("usp_GetLegislatorIndustryFinance", inputParameters, CommandType.StoredProcedure);

            return results.ToList();
        }

        public async Task<List<Rating>> GetLegislatorRatings(string id)
        {
            var inputParameters = new Dictionary<string, object>
            {
                { "@Id", id}

            };

            var results = await GovLookupDbContext.SqlQuery<Rating>("usp_GetLegislatorRatings", inputParameters, CommandType.StoredProcedure);

            return results.ToList();
        }
        public async Task<List<KeyVote>> GetLegislatorKeyVotes(string id)
        {
            var inputParameters = new Dictionary<string, object>
            {
                { "@Id", id}

            };

            var results = await GovLookupDbContext.SqlQuery<KeyVote>("usp_GetLegislatorKeyVotes", inputParameters, CommandType.StoredProcedure);

            return results.ToList();
        }

        public async Task<List<Bill>> GetLegislatorBills(string id)
        {
            var inputParameters = new Dictionary<string, object>
            {
                    { "@Id", id}
             };

            var results = await GovLookupDbContext.SqlQuery<Bill>("usp_GetLegislatorBills", inputParameters, CommandType.StoredProcedure);

            return results.ToList();
        }

        public async Task<List<Committee>> GetLegislatorCommittees(string id)
        {
            var inputParameters = new Dictionary<string, object>
            {
                    { "@Id", id}
             };

            var results = await GovLookupDbContext.SqlQuery<Committee>("usp_GetLegislatorCommittees", inputParameters, CommandType.StoredProcedure);

            return results.ToList();
        }

        #endregion

        #region cabinet

        public async Task<List<Cabinet>> GetAllCabinet()
        {

            var results = await GovLookupDbContext.SqlQuery<Cabinet>("usp_GetCabinetAll", null, CommandType.StoredProcedure);

            return results.ToList();
        }


        public async Task<Cabinet> GetCabinetById(string id)
        {
            var inputParameters = new Dictionary<string, object>
            {
                { "@Id", id }

            };

            var result = await GovLookupDbContext.SqlQuery<Cabinet>("usp_GetCabinetById", inputParameters, CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

       

         public async Task<List<School>> GetCabinetEducation(string id)
        {
            var inputParameters = new Dictionary<string, object>
            {
                { "@Id", id }

            }; 

            var results = await GovLookupDbContext.SqlQuery<School>("usp_GetCabinetEducation", inputParameters, CommandType.StoredProcedure);

            return results.ToList();
        }

        public async Task<List<JobPosition>> GetCabinetJobHistory(string id)
        {
            var inputParameters = new Dictionary<string, object>
            {
                { "@Id", id }

            };

            var results = await GovLookupDbContext.SqlQuery<JobPosition>("usp_GetCabinetJobHistory", inputParameters, CommandType.StoredProcedure);

            return results.ToList();
        }

        #endregion

        #region judiciary

        public async Task<List<Judiciary>> GetAllJudiciary()
        {

            var results = await GovLookupDbContext.SqlQuery<Judiciary>("usp_GetJudiciaryAll", null, CommandType.StoredProcedure);

            return results.ToList();
        }
      
        public async Task<Judiciary> GetJudiciaryById(string id)
        {
            var inputParameters = new Dictionary<string, object>
            {
                { "@Id", id }
            };

            var result = await GovLookupDbContext.SqlQuery<Judiciary>("usp_GetJudiciaryById", inputParameters, CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }
            
    

       
        public async Task<List<KeyDecisions>>GetJudiciaryKeyDecisions(string id)
        {
            var inputParameters = new Dictionary<string, object>
            {
                { "@Id", id}

            };

            var results = await GovLookupDbContext.SqlQuery<KeyDecisions>("usp_GetJudiciaryKeyDecisions", inputParameters, CommandType.StoredProcedure);

            return results.ToList();
        }
        public async Task<List<KeyDecisionsOpinions>> GetJudiciaryKeyDecisionsOpinions(string id)
        {
            var inputParameters = new Dictionary<string, object>
            {
                { "@Id", id}

            };

            var results = await GovLookupDbContext.SqlQuery<KeyDecisionsOpinions>("usp_GetJudiciaryKeyDecisionsOpinions", inputParameters, CommandType.StoredProcedure);

            return results.ToList();
        }

       
        public async Task<List<RollCallDecision>> GetJudiciaryRollCallDecision(string docket)
        {
            var inputParameters = new Dictionary<string, object>
            {
                { "@Docket", docket}

            };

            var results = await GovLookupDbContext.SqlQuery<RollCallDecision>("usp_GetJudiciaryRollCallDecision", inputParameters, CommandType.StoredProcedure);

            return results.ToList();
        }

        #endregion

        #region bills

        public async Task<List<CurrentBills>> GetCurrentBills()
        {
            var results = await GovLookupDbContext.SqlQuery<CurrentBills>("usp_GetCurrentBills", null, CommandType.StoredProcedure);

            return results.ToList();
        }

        #endregion

    }
}