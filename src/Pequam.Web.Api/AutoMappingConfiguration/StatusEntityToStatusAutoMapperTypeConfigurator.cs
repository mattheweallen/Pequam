using AutoMapper;
using Pequam.Common.TypeMapping;
using Pequam.Data.Entities;

namespace Pequam.Web.Api.AutoMappingConfiguration
{
    public class StatusEntityToStatusAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
    {
        public void Configure()
        {
            Mapper.CreateMap<Status, Models.Status>();
        }
    }
}