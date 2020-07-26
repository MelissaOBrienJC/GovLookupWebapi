using System;
using System.Collections.Generic;

using System.Data;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;
using GovLookup.DataAccess.RepositoryContract;


namespace GovLookup.DataAccess.Repository
{



    public class BaseRepository : IBaseRepository
    {
         public GovLookupDbContext GovLookupDbContext { get; set; }
     }
}