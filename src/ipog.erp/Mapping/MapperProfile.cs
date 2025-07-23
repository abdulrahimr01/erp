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
            CreateMap<UserLogin, UserLoginModel>().ReverseMap();
            CreateMap<UpdatePassword, UpdatePasswordModel>().ReverseMap();

            CreateMap<Role, RoleModel>().ReverseMap();
            CreateMap<Role, GetRoleModel>();
            CreateMap<Role, RoleModelCollection>();

            CreateMap<Supplier, SupplierModel>().ReverseMap();
            CreateMap<Supplier, GetSupplierModel>();
            CreateMap<Supplier, SupplierModelCollection>();

            CreateMap<Businesstype, BusinesstypeModel>().ReverseMap();
            CreateMap<Businesstype, GetBusinesstypeModel>();
            CreateMap<Businesstype, BusinesstypeModelCollection>();

            CreateMap<Customer, CustomerModel>().ReverseMap();
            CreateMap<Customer, GetCustomerModel>();
            CreateMap<Customer, CustomerModelCollection>();

            CreateMap<Category, CategoryModel>().ReverseMap();
            CreateMap<Category, GetCategoryModel>();
            CreateMap<Category, CategoryModelCollection>();

            CreateMap<Hsn, HsnModel>().ReverseMap();
            CreateMap<Hsn, GetHsnModel>();
            CreateMap<Hsn, HsnModelCollection>();
        }
    }
}
