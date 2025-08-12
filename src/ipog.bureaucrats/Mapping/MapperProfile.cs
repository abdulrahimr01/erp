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
            CreateMap<UserLogin, UserLoginModel>().ReverseMap();
            CreateMap<UpdatePassword, UpdatePasswordModel>().ReverseMap();

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

            CreateMap<ContactInfo, ContactInfoModel>().ReverseMap();
            CreateMap<ContactInfo, GetContactInfoModel>();
            CreateMap<ContactInfo, ContactInfoModelCollection>();

            CreateMap<DefaultPage, DefaultPageModel>().ReverseMap();
            CreateMap<DefaultPage, GetDefaultPageModel>();
            CreateMap<DefaultPage, DefaultPageModelCollection>();

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

            CreateMap<Tnpsccoursevideos, TnpsccoursevideosModel>().ReverseMap();
            CreateMap<Tnpsccoursevideos, GetTnpsccoursevideosModel>();
            CreateMap<Tnpsccoursevideos, TnpsccoursevideosModelCollection>();

            CreateMap<Upsccoursevideos, UpsccoursevideosModel>().ReverseMap();
            CreateMap<Upsccoursevideos, GetUpsccoursevideosModel>();
            CreateMap<Upsccoursevideos, UpsccoursevideosModelCollection>();

            CreateMap<Wishlist, WishlistModel>().ReverseMap();
            CreateMap<Wishlist, GetWishlistModel>();
            CreateMap<Wishlist, WishlistModelCollection>();
            CreateMap<PaginationModel, Pagination>().ReverseMap();

            CreateMap<Cartpage, CartpageModel>().ReverseMap();
            CreateMap<Cartpage, GetCartpageModel>();
            CreateMap<Cartpage, CartpageModelCollection>();

            CreateMap<CurrentAffairs, CurrentAffairsModel>().ReverseMap();
            CreateMap<CurrentAffairs, GetCurrentAffairsModel>();
            CreateMap<CurrentAffairs, CurrentAffairsModelCollection>();

            CreateMap<Editorials, EditorialsModel>().ReverseMap();
            CreateMap<Editorials, GetEditorialsModel>();
            CreateMap<Editorials, EditorialsModelCollection>();

            CreateMap<About, AboutModel>().ReverseMap();
            CreateMap<About, GetAboutModel>();
            CreateMap<About, AboutModelCollection>();
        }
    }
}
