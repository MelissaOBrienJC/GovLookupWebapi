using GovLookup.Models;
using GovLookup.Business.Contract;
using GovLookup.DataAccess.RepositoryContract;
using System.Collections.Generic;
using GovLookupWebapi.Models;
using AutoMapper;
using System.Threading.Tasks;

namespace GovLookup.Business.Implementation
{
    public class CabinetService : ICabinetService
    {

        public IGovLookupRepository GovLookupRepository { get; set; }
        public IMapper mapper { get; set; }

        public async Task<IEnumerable<CabinetSummaryDto>> GetCabinet()
        {

            List<Cabinet> cabinetsFromDb;
            cabinetsFromDb = await GovLookupRepository.GetAllCabinet();
            return mapper.Map<IEnumerable<CabinetSummaryDto>>(cabinetsFromDb);

        }
        public async Task<CabinetDetailDto> GetCabinetById(string id)
        {
            var cabinetFromDb = await GovLookupRepository.GetCabinetById(id);
            cabinetFromDb =  await AddCabinetData(cabinetFromDb);
            return mapper.Map<CabinetDetailDto>(cabinetFromDb);
        }

        private async Task<Cabinet> AddCabinetData(Cabinet cabinet)
        {
            if (cabinet == null) return cabinet;
                        
            cabinet.Education = await GovLookupRepository.GetCabinetEducation(cabinet.Id);
            cabinet.JobHistory = await GovLookupRepository.GetCabinetJobHistory(cabinet.Id);
            return cabinet;

        }
      
    }

}