using AutoMapper;
using ipog.bureaucrats.Entity;
using ipog.bureaucrats.Models;

namespace ipog.bureaucrats.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<User, GetUserModel>();
            CreateMap<User, UserModelCollection>();
            CreateMap<Role, RoleModel>().ReverseMap();
            CreateMap<Role, GetRoleModel>();
            CreateMap<Role, RoleModelCollection>();
            CreateMap<Menu, MenuModel>().ReverseMap();
            CreateMap<Menu, GetMenuModel>();
            CreateMap<Menu, MenuModelCollection>();
            CreateMap<Exams, ExamsModel>().ReverseMap();
            CreateMap<Exams, GetExamsModel>();
            CreateMap<Exams, ExamsModelCollection>();
            CreateMap<Papers, PapersModel>().ReverseMap();
            CreateMap<Papers, GetPapersModel>();
            CreateMap<Papers, PapersModelCollection>();
        }
    }
}
