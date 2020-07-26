using GovLookup.Models;
using GovLookup.Business.Contract;
using GovLookup.DataAccess.RepositoryContract;
using System.Collections.Generic;
using GovLookupWebapi.Models;
using AutoMapper;

namespace GovLookup.Business.Implementation
{
    public class CabinetService : ICabinetService
    {

        public IGovLookupRepository GovLookupRepository { get; set; }
        public IMapper mapper { get; set; }

        public IEnumerable<CabinetSummaryDto> GetCabinet()
        {

            List<Cabinet> cabinetsFromDb;
            cabinetsFromDb = GovLookupRepository.GetAllCabinet();
            return mapper.Map<IEnumerable<CabinetSummaryDto>>(cabinetsFromDb);

        }
        public CabinetDetailDto GetCabinetById(string id)
        {
            var cabinetFromDb = GovLookupRepository.GetCabinetById(id);
            AddCabinetData(cabinetFromDb);
            return mapper.Map<CabinetDetailDto>(cabinetFromDb);
        }

        private void AddCabinetData(Cabinet cabinet)
        {
            if (cabinet == null) return;
                        
            cabinet.Education = GovLookupRepository.GetCabinetEducation(cabinet.Id);
            cabinet.JobHistory = GovLookupRepository.GetCabinetJobHistory(cabinet.Id);

        }
      
    }

}