using GovLookup.Models;
using GovLookupWebapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace GovLookup.Business.Contract
{
    public interface IJudiciaryService
    {
        Task<IEnumerable<JudiciarySummaryDto>> GetJudiciary();
        Task<JudiciaryDetailDto> GetJudiciaryById(string id);
       
    }
}