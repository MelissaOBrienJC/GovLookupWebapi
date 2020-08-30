
using GovLookup.DataAccess;
using GovLookup.DataAccess.Repository;
using GovLookup.DataAccess.RepositoryContract;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GovLookupWebapi.Filters
{

   
    public class ApiKeyAuthAttribute : Attribute, IAsyncActionFilter
    {
        private const string ApiKeyHeaderName = "ApiKey";

        
         public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
                     
            if (RequireApiKey(context))
            {           
                if ( !context.HttpContext.Request.Headers.TryGetValue(ApiKeyHeaderName, out var apiKey))
                {
                    context.Result = new UnauthorizedResult();
                    return;
                }
                else
                {
                    var config = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
                    List<string> govLookupApiKeys = config.GetSection("ApiKeys").Get<List<string>>();

                    foreach (string govLookupApiKey in govLookupApiKeys)
                    {
                        if (!govLookupApiKey.Equals(apiKey.ToString()))
                        {
                            context.Result = new UnauthorizedResult();
                            return;
                        }
                    }   
                }
            }
            await next();
            
        }

        private Boolean RequireApiKey(ActionExecutingContext context)
        {
            string refererUrl = "";
           
            var config = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
            List<string> urlExceptions = config.GetSection("UrlKeyException").Get<List<string>>();
            if (context.HttpContext.Request.Headers.TryGetValue("Referer", out var refererHeders))
            {
                refererUrl = refererHeders.FirstOrDefault().ToString();
            }
            foreach (string urlException in urlExceptions)
            {
                if (refererUrl.Contains(urlException))
                {
                    return false;
                }
            }

            return true;


        }
    }
}


