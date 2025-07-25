using ipog.bureaucrats.DataSource.IRepository;
using ipog.bureaucrats.Entity;
using ipog.bureaucrats.Extension;
using ipog.bureaucrats.Mapping;
using ipog.bureaucrats.Models;
using ipog.bureaucrats.Workflow.IServices;

namespace ipog.bureaucrats.Workflow.Services
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly IMapping _mapper;
        private readonly IUserRepository _iUserRepository;

        public UserService(
            ILogger<UserService> logger,
            IMapping mapper,
            IUserRepository iUserRepository
        )
        {
            _logger = logger;
            _mapper = mapper;
            _iUserRepository = iUserRepository;
        }

        public async Task<GetResponse<GetUserModel>> GetById(long id)
        {
            List<Dictionary<string, object>> result = await _iUserRepository.GetById(id);
            User? user = result
                .Select(static row => DataMapperExtensions.MapRowToModel<User>(row))
                .FirstOrDefault();
            if (user == null)
            {
                return new GetResponse<GetUserModel>()
                {
                    Code = 200,
                    Success = true,
                    Message = "No record found",
                };
            }
            GetUserModel response = await _mapper.CreateMap<GetUserModel, User>(user);
            return new GetResponse<GetUserModel>()
            {
                Code = 200,
                Success = true,
                Message = "Get successfully.",
                Data = response,
            };
        }

        public async Task<CollectionResponse<UserModelCollection>> GetAll()
        {
            List<Dictionary<string, object>> result = await _iUserRepository.GetAll();
            List<User> users = result
                .Select(static row => DataMapperExtensions.MapRowToModel<User>(row))
                .ToList();
            UserModelCollection collection = await _mapper.CreateMap<
                UserModelCollection,
                List<User>
            >(users);
            return new CollectionResponse<UserModelCollection>()
            {
                Code = 200,
                Success = true,
                Message = "Get successfully.",
                Record = new() { Count = collection.Count, Data = collection },
            };
        }

        public async Task<UserModelCollection> GetFilter(PaginationModel paginationModel)
        {
            Pagination pagination = await _mapper.CreateMap<Pagination, PaginationModel>(
                paginationModel
            );
            List<Dictionary<string, object>> result = await _iUserRepository.GetFilter(pagination);
            List<User> users = result
                .Select(static row => DataMapperExtensions.MapRowToModel<User>(row))
                .ToList();
            UserModelCollection collection = await _mapper.CreateMap<
                UserModelCollection,
                List<User>
            >(users);
            return collection;
        }

        public async Task<GetResponse<GetUserModel>> UserLogin(UserLoginModel requestModel)
        {
            UserLogin request = await _mapper.CreateMap<UserLogin, UserLoginModel>(requestModel);
            List<Dictionary<string, object>> result = await _iUserRepository.UserLogin(request);
            User? user = result
                .Select(static row => DataMapperExtensions.MapRowToModel<User>(row))
                .FirstOrDefault();
            if (user == null)
            {
                return new GetResponse<GetUserModel>()
                {
                    Code = 200,
                    Success = true,
                    Message = "Invalid User Credential",
                };
            }
            GetUserModel response = await _mapper.CreateMap<GetUserModel, User>(user);
            return new GetResponse<GetUserModel>()
            {
                Code = 200,
                Success = true,
                Message = "Login successfully.",
                Data = response,
            };
        }

        public async Task<GetResponse<GetUserModel>> UpdatePassword(
            UpdatePasswordModel requestModel
        )
        {
            UpdatePassword request = await _mapper.CreateMap<UpdatePassword, UpdatePasswordModel>(
                requestModel
            );
            List<Dictionary<string, object>> result = await _iUserRepository.UpdatePassword(
                request
            );
            User? user = result
                .Select(static row => DataMapperExtensions.MapRowToModel<User>(row))
                .FirstOrDefault();
            if (user == null)
            {
                return new GetResponse<GetUserModel>()
                {
                    Code = 200,
                    Success = true,
                    Message = "Invalid Password",
                };
            }
            GetUserModel response = await _mapper.CreateMap<GetUserModel, User>(user);
            return new GetResponse<GetUserModel>()
            {
                Code = 200,
                Success = true,
                Message = "Password Updated successfully.",
                Data = response,
            };
        }

        public async Task<Response> Insert(UserModel userModel)
        {
            User user = await _mapper.CreateMap<User, UserModel>(userModel);
            bool success = await _iUserRepository.Insert(user);
            if (success)
            {
                return new Response()
                {
                    Code = 200,
                    Success = true,
                    Message = "User inserted successfully.",
                };
            }
            return new Response()
            {
                Code = 200,
                Success = false,
                Message = "User inserted failed.",
            };
        }

        public async Task<string> Update(UserModel userModel)
        {
            User user = await _mapper.CreateMap<User, UserModel>(userModel);
            bool success = await _iUserRepository.Update(user);
            if (success)
                return "User updated successfully.";
            else
                return "User update failed.";
        }

        public async Task<string> Delete(long id)
        {
            try
            {
                bool deleted = await _iUserRepository.Delete(id);
                if (deleted)
                    return "User deleted successfully.";
                else
                    return "User not found.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> SetActiveStatus(long id)
        {
            try
            {
                bool success = await _iUserRepository.SetActiveStatus(id);
                if (success)
                    return "User status updated to active.";
                else
                    return "User not found.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> SetInActiveStatus(long id)
        {
            try
            {
                bool success = await _iUserRepository.SetInActiveStatus(id);
                if (success)
                    return "User status updated to inactive.";
                else
                    return "User not found.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
