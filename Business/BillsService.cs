using GovLookup.Models;
using GovLookup.Business.Contract;
using GovLookup.DataAccess.RepositoryContract;
using System.Collections.Generic;
using GovLookupWebapi.Models;
using AutoMapper;
using RefreshData.DataModel;

namespace GovLookup.Business.Implementation
{
    public class BillsService : IBillsService
    {

        public IGovLookupRepository GovLookupRepository { get; set; }
        public IMapper mapper { get; set; }

        public IEnumerable<CurrentBillsDto> GetCurrentBills()
        {

            List<CurrentBills> currentBillFromDb;
            currentBillFromDb = GovLookupRepository.GetCurrentBills();
            return mapper.Map<IEnumerable<CurrentBillsDto>>(currentBillFromDb);

        }
             
    }

}