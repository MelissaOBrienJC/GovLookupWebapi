using GovLookup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace GovLookup.DataAccess.RepositoryContract
{
        public interface IBaseRepository
        {
      
        GovLookupDbContext GovLookupDbContext { get; set; }
    }
}