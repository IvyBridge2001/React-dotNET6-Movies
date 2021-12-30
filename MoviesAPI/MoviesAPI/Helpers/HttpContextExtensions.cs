using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Helpers
{
    public static class HttpContextExtensions
    {
        public async static Task InsertParametersPagionationIntoHeader<T>(this HttpContext httpContext,
            IQueryable<T> queryable)
        {
            if (queryable == null) { throw new ArgumentNullException(nameof(httpContext)); }

                double count = await queryable.CountAsync();
                httpContext.Response.Headers.Add("totalAmmountOfRecords", count.ToString());
        }
    }
}
