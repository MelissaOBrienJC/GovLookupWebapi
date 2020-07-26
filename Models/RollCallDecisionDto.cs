using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GovLookupWebapi.Models
{
    public class RollCallDecisionDto
    {
        public int JudiciaryId { get; set; }
        public string VoteCast { get; set; }
        public string LastName { get; set; }
    }
}
