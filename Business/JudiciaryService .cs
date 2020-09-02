using GovLookup.Models;
using GovLookup.Business.Contract;
using GovLookup.DataAccess.RepositoryContract;
using System.Collections.Generic;
using GovLookupWebapi.Models;
using AutoMapper;
using System.Threading.Tasks;

namespace GovLookup.Business.Implementation
{
    public class JudiciaryService : IJudiciaryService
    {

        public IGovLookupRepository GovLookupRepository { get; set; }
        public IMapper mapper { get; set; }

        public async Task<IEnumerable<JudiciarySummaryDto>> GetJudiciary()
        {
            List<Judiciary> judiciarysFromDb;
            judiciarysFromDb = await GovLookupRepository.GetAllJudiciary();
            return mapper.Map<IEnumerable<JudiciarySummaryDto>>(judiciarysFromDb);
        }

        public async Task<JudiciaryDetailDto> GetJudiciaryById(string id)
        {
            var judiciaryFromDb = await GovLookupRepository.GetJudiciaryById(id);
            judiciaryFromDb = await AddJudiciaryData(judiciaryFromDb);
            return mapper.Map<JudiciaryDetailDto>(judiciaryFromDb);
        }


        private async Task<Judiciary> AddJudiciaryData(Judiciary judiciary)
        {
            if (judiciary == null) return judiciary;


            judiciary.KeyDecisions = await  GovLookupRepository.GetJudiciaryKeyDecisions(judiciary.Id);
            if (judiciary.KeyDecisions != null)
            {
                foreach (KeyDecisions decision in judiciary.KeyDecisions)
                {
                    decision.RollCallDecision = await GovLookupRepository.GetJudiciaryRollCallDecision(decision.Docket);
                }
            }
            judiciary.KeyDecisionsOpinions = await  GovLookupRepository.GetJudiciaryKeyDecisionsOpinions(judiciary.Id);

            return judiciary;
        }

    }

}