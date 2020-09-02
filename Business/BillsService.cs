using GovLookup.Models;
using GovLookup.Business.Contract;
using GovLookup.DataAccess.RepositoryContract;
using System.Collections.Generic;
using GovLookupWebapi.Models;
using AutoMapper;
using RefreshData.DataModel;
using System.Threading.Tasks;

namespace GovLookup.Business.Implementation
{
    public class BillsService : IBillsService
    {

        public IGovLookupRepository GovLookupRepository { get; set; }
        public IMapper mapper { get; set; }

        public async Task<IEnumerable<CurrentBillsDto>> GetCurrentBills()
        {

            List<CurrentBills> currentBillFromDb;
            currentBillFromDb = await  GovLookupRepository.GetCurrentBills();
            return mapper.Map<IEnumerable<CurrentBillsDto>>(currentBillFromDb);

        }
             
    }

}