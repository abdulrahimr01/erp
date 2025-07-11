using ipog.erp.DataSource.IRepository;
using ipog.erp.Entity;
using ipog.erp.Extension;
using ipog.erp.Mapping;
using ipog.erp.Models;
using ipog.erp.Workflow.IServices;

namespace ipog.erp.Workflow.Services
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

        public async Task<GetUserModel> GetById(long id)
        {
            List<Dictionary<string, object>> result = await _iUserRepository.GetById(id);
            User? user = result
                .Select(static row => DataMapperExtensions.MapRowToModel<User>(row))
                .FirstOrDefault();
            GetUserModel response = await _mapper.CreateMap<GetUserModel, User>(user);
            return response;
        }

        public async Task<UserModelCollection> GetAll()
        {
            List<Dictionary<string, object>> result = await _iUserRepository.GetAll();
            List<User> users = result
                .Select(static row => DataMapperExtensions.MapRowToModel<User>(row))
                .ToList();
            UserModelCollection collection = await _mapper.CreateMap<
                UserModelCollection,
                List<User>
            >(users);
            return collection;
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

        public async Task<string> Insert(UserModel userModel)
        {
            User user = await _mapper.CreateMap<User, UserModel>(userModel);
            bool success = await _iUserRepository.Insert(user);
            if (success)
                return "User inserted successfully.";
            else
                return "User insert failed.";
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
