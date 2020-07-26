﻿using GovLookup.Models;
using GovLookupWebapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GovLookup.Business.Contract
{
    public interface IJudiciaryService
    {
        IEnumerable<JudiciarySummaryDto> GetJudiciary();
        JudiciaryDetailDto GetJudiciaryById(string id);
       
    }
}