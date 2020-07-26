using GovLookup.Models;
using GovLookupWebapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GovLookup.Business.Contract
{
    public interface ILegislatorsService
    {
        IEnumerable<LegislatorSummaryDto> GetLegislators(string searchValue);
        LegislatorDetailDto GetLegislatorById(string id);
       
    }
}