using GovLookup.Models;
using GovLookupWebapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace GovLookup.Business.Contract
{
    public interface ILegislatorsService
    {
        Task<IEnumerable<LegislatorSummaryDto>> GetLegislators(string searchValue);
        Task<LegislatorDetailDto> GetLegislatorById(string id);
       
    }
}