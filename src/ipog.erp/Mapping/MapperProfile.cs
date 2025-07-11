using AutoMapper;
using ipog.erp.Entity;
using ipog.erp.Models;

namespace ipog.erp.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<User, GetUserModel>();
            CreateMap<User, UserModelCollection>();
        }
    }
}
