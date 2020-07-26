using AutoMapper;
using GovLookup.Models;
using GovLookupWebapi.Models;

namespace GovLookupWebapi.Mapping
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {

            #region legislators
            CreateMap<Legislator, LegislatorSummaryDto>();
            CreateMap<Legislator, LegislatorDetailDto>();
            CreateMap<Rating, RatingDto>();
            CreateMap<RollCallDecision, RollCallDecisionDto>();
            CreateMap<Bill, BillDto>();
            CreateMap<Committee, CommiteeDto>();
            CreateMap<IndustryFinance, IndustryFinanceDto>();
            CreateMap<KeyVote, KeyVoteDto>();
            #endregion

        #region cabinet
        CreateMap<Cabinet, CabinetSummaryDto>();
            CreateMap<Cabinet, CabinetDetailDto>();
            CreateMap<School, SchoolDto>();
            CreateMap<JobPosition, JobPositionDto>();
            #endregion

            #region judiciary
            CreateMap<Judiciary, JudiciarySummaryDto>();
            CreateMap<Judiciary, JudiciaryDetailDto>();
            CreateMap<KeyDecisions, KeyDecisionsDto>();
            CreateMap<KeyDecisionsOpinions, KeyDecisionsOpinionsDto>();
            #endregion
            ;
        }
    }
}
