using GovLookup.Models;
using GovLookup.Business.Contract;
using GovLookup.DataAccess.RepositoryContract;
using System.Collections.Generic;
using GovLookupWebapi.Models;
using AutoMapper;

namespace GovLookup.Business.Implementation
{
    public class JudiciaryService : IJudiciaryService
    {

        public IGovLookupRepository GovLookupRepository { get; set; }
        public IMapper mapper { get; set; }

        public IEnumerable<JudiciarySummaryDto> GetJudiciary()
        {
            List<Judiciary> judiciarysFromDb;
            judiciarysFromDb = GovLookupRepository.GetAllJudiciary();
            return mapper.Map<IEnumerable<JudiciarySummaryDto>>(judiciarysFromDb);
        }

        public JudiciaryDetailDto GetJudiciaryById(string id)
        {
            var judiciaryFromDb = GovLookupRepository.GetJudiciaryById(id);
            AddJudiciaryData(judiciaryFromDb);
            return mapper.Map<JudiciaryDetailDto>(judiciaryFromDb);
        }

               
        private void AddJudiciaryData(Judiciary judiciary)
        {
            if (judiciary == null) return;
                       
            judiciary.KeyDecisions = GovLookupRepository.GetJudiciaryKeyDecisions(judiciary.Id);
            if (judiciary.KeyDecisions != null)
            {
                foreach (KeyDecisions decision in judiciary.KeyDecisions)
                {
                    decision.RollCallDecision = GovLookupRepository.GetJudiciaryRollCallDecision(decision.Docket);
                }
            }
            judiciary.KeyDecisionsOpinions = GovLookupRepository.GetJudiciaryKeyDecisionsOpinions(judiciary.Id);
        }

    }

}