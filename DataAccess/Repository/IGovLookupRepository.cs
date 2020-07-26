using GovLookup.Models;
using GovLookup.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace GovLookup.DataAccess.RepositoryContract
{
    public interface IGovLookupRepository
    {


        #region legislators

        List<Legislator> GetAllLegislators();
        Legislator GetLegislatorById(string id);
        List<Legislator> GetLegislatorsByName(string name);
        List<Legislator> GetLegislatorsByZipcode(string zipcode);
        List<Legislator> GetLegislatorsByLngLat(string lng, string lat);
        List<KeyVote> GetLegislatorKeyVotes(string id);
        List<Rating> GetLegislatorRatings(string id);
        List<Bill> GetLegislatorBills(string id);
        List<IndustryFinance> GetLegislatorIndustryFinance(string id);
        List<Committee> GetLegislatorCommittees(string id);
        #endregion

        #region cabinet
        List<Cabinet> GetAllCabinet();
        Cabinet GetCabinetById(string id);
        List<JobPosition> GetCabinetJobHistory(string id);
        List<School> GetCabinetEducation(string id);
        #endregion

        #region judiciary
        List<Judiciary> GetAllJudiciary();
        Judiciary GetJudiciaryById(string id);
        List<KeyDecisions> GetJudiciaryKeyDecisions(string id);
        List<KeyDecisionsOpinions> GetJudiciaryKeyDecisionsOpinions(string id);
        List<RollCallDecision> GetJudiciaryRollCallDecision(string docket);
        #endregion
    }
}