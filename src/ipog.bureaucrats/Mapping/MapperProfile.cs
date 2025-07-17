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
            CreateMap<Books, BooksModel>().ReverseMap();
            CreateMap<Books, GetBooksModel>();
            CreateMap<Books, BooksModelCollection>();
            CreateMap<Coursevideos, CoursevideosModel>().ReverseMap();
            CreateMap<Coursevideos, GetCoursevideosModel>();
            CreateMap<Coursevideos, CoursevideosModelCollection>();
            CreateMap<Homeabout, HomeaboutModel>().ReverseMap();
            CreateMap<Homeabout, GetHomeaboutModel>();
            CreateMap<Homeabout, HomeaboutModelCollection>();
            CreateMap<Tnpscabout, TnpscaboutModel>().ReverseMap();
            CreateMap<Tnpscabout, GetTnpscaboutModel>();
            CreateMap<Tnpscabout, TnpscaboutModelCollection>();
            CreateMap<Upscabout, UpscaboutModel>().ReverseMap();
            CreateMap<Upscabout, GetUpscaboutModel>();
            CreateMap<Upscabout, UpscaboutModelCollection>();
        }
    }
}
