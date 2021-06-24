using AutoMapper;

using Helpers;
using AtkTennisApp.Models;

namespace AtkTennisApp.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ApplicationLog, ApplicationLogsDto>();
            CreateMap<ApplicationLogsDto, ApplicationLog>();

            CreateMap<ErrorLog, ErrorLogsDto>();
            CreateMap<ErrorLogsDto, ErrorLog>();


            CreateMap<QueryLog, QueryLogsDto>();
            CreateMap<QueryLogsDto, QueryLog>();

            CreateMap<UserLog, UserLogsDto>();
            CreateMap<UserLogsDto, UserLog>();

            CreateMap<UserSettings, Helpers.Dto.ViewDtos.UserSettingsDto>();
            CreateMap<Helpers.Dto.ViewDtos.UserSettingsDto, UserSettings>();

        }
    }
}
