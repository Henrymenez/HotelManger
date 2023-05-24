    using HotelManager.DAL.Configurations;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.BLL.Extensions
{
    public static class ApplicationBuilderExtention
    {
        public static IApplicationBuilder AddGlobalErrorHandler(this IApplicationBuilder applicationBuilder) 
            => applicationBuilder.UseMiddleware<GlobalExceptionHandlingMiddleware>();
    }
}
