using Autofac;
using GovLookup.Business.Contract;
using GovLookup.Business.Implementation;
using GovLookup.DataAccess;
using GovLookup.DataAccess.Repository;
using GovLookup.DataAccess.RepositoryContract;
using GovLookupWebapi.Filters;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;


namespace GovLookup.DependencyInjection
{
    public class DependencyLoader : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // register database context
            builder.RegisterType<GovLookupDbContext>().PropertiesAutowired().InstancePerLifetimeScope();

            //register repositories
            builder.Register<IGovLookupRepository>(c => new GovLookupRepository()).PropertiesAutowired();
                
            // register services
            builder.Register<ILegislatorsService>(c => new LegislatorsService()).PropertiesAutowired().InstancePerLifetimeScope();
            builder.Register<ICabinetService>(c => new CabinetService()).PropertiesAutowired().InstancePerLifetimeScope();
            builder.Register<IJudiciaryService>(c => new JudiciaryService()).PropertiesAutowired().InstancePerLifetimeScope();

        }
    }
}
