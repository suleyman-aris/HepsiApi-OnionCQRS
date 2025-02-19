using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using YoutubeApi.Application.Interface.AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeApi.Mapper
{
    public static class Registration
    {
        public static void AddCustomerMapper(this IServiceCollection services)
        {
            services.AddSingleton<Application.Interface.AutoMapper.IMapper, AutoMapper.Mapper>();
        }
    }
}
