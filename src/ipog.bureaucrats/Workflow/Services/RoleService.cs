using ipog.bureaucrats.DataSource.IRepository;
using ipog.bureaucrats.Entity;
using ipog.bureaucrats.Extension;
using ipog.bureaucrats.Mapping;
using ipog.bureaucrats.Models;
using ipog.bureaucrats.Workflow.IServices;

namespace ipog.bureaucrats.Workflow.Services
{
    public class RoleService : IRoleService
    {
        private readonly ILogger<RoleService> _logger;
        private readonly IMapping _mapper;
        private readonly IRoleRepository _iRoleRepository;

        public RoleService(
            ILogger<RoleService> logger,
            IMapping mapper,
            IRoleRepository iRoleRepository
        )
        {
            _logger = logger;
            _mapper = mapper;
            _iRoleRepository = iRoleRepository;
        }

        public async Task<GetResponse<GetRoleModel>> GetById(long id)
        {
            List<Dictionary<string, object>> result = await _iRoleRepository.GetById(id);
            Role? role = result
                .Select(static row => DataMapperExtensions.MapRowToModel<Role>(row))
                .FirstOrDefault();
            if (role == null)
            {
                return new GetResponse<GetRoleModel>()
                {
                    Code = 200,
                    Success = true,
                    Message = "No record found",
                };
            }
            GetRoleModel response = await _mapper.CreateMap<GetRoleModel, Role>(role);
            return new GetResponse<GetRoleModel>()
            {
                Code = 200,
                Success = true,
                Message = "Get successfully.",
                Data = response,
            };
        }

        public async Task<CollectionResponse<RoleModelCollection>> GetAll()
        {
            List<Dictionary<string, object>> result = await _iRoleRepository.GetAll();
            List<Role> roles = result
                .Select(static row => DataMapperExtensions.MapRowToModel<Role>(row))
                .ToList();
            RoleModelCollection collection = await _mapper.CreateMap<
                RoleModelCollection,
                List<Role>
            >(roles);
            return new CollectionResponse<RoleModelCollection>()
            {
                Code = 200,
                Success = true,
                Message = "Get successfully.",
                Record = new() { Count = collection.Count, Data = collection },
            };
        }

        public async Task<RoleModelCollection> GetFilter(PaginationModel paginationModel)
        {
            Pagination pagination = await _mapper.CreateMap<Pagination, PaginationModel>(
                paginationModel
            );
            List<Dictionary<string, object>> result = await _iRoleRepository.GetFilter(pagination);
            List<Role> roles = result
                .Select(static row => DataMapperExtensions.MapRowToModel<Role>(row))
                .ToList();
            RoleModelCollection collection = await _mapper.CreateMap<
                RoleModelCollection,
                List<Role>
            >(roles);
            return collection;
        }

        public async Task<Response> Insert(RoleModel roleModel)
        {
            Role role = await _mapper.CreateMap<Role, RoleModel>(roleModel);
            bool success = await _iRoleRepository.Insert(role);
            if (success)
            {
                return new Response()
                {
                    Code = 200,
                    Success = true,
                    Message = "Role inserted successfully.",
                };
            }
            return new Response()
            {
                Code = 200,
                Success = false,
                Message = "Role inserted failed.",
            };
        }

        public async Task<Response> Update(RoleModel roleModel)
        {
            Role role = await _mapper.CreateMap<Role, RoleModel>(roleModel);
            bool success = await _iRoleRepository.Update(role);
            if (success)
            {
                return new Response()
                {
                    Code = 200,
                    Success = true,
                    Message = "Role updated successfully.",
                };
            }
            return new Response()
            {
                Code = 200,
                Success = false,
                Message = "Role update failed.",
            };
        }

        public async Task<Response> Delete(long id)
        {
            try
            {
                bool deleted = await _iRoleRepository.Delete(id);
                if (deleted)
                {
                    return new Response()
                    {
                        Code = 200,
                        Success = true,
                        Message = "Role deleted successfully.",
                    };
                }
                return new Response()
                {
                    Code = 200,
                    Success = false,
                    Message = "Role not found.",
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    Code = 500,
                    Message = ex.Message,
                    Success = false
                };
            }
        }

        public async Task<Response> SetActiveStatus(long id)
        {
            try
            {
                bool success = await _iRoleRepository.SetActiveStatus(id);
                if (success)
                {
                    return new Response
                    {
                        Code = 200,
                        Message = "Role status updated to active.",
                        Success = true
                    };
                }
                else
                {
                    return new Response
                    {
                        Code = 404,
                        Message = "Role entry not found",
                        Success = false
                    };
                }
            }
            catch (Exception ex)
            {
                return new Response
                {
                    Code = 500,
                    Message = ex.Message,
                    Success = false
                };
            }
        }

        public async Task<Response> SetInActiveStatus(long id)
        {
            try
            {
                bool success = await _iRoleRepository.SetInActiveStatus(id);
                if (success)
                {
                    return new Response
                    {
                        Code = 200,
                        Message = "Role status updated to inactive",
                        Success = true
                    };
                }
                else
                {
                    return new Response
                    {
                        Code = 404,
                        Message = "Role entry not found",
                        Success = false
                    };
                }
            }
            catch (Exception ex)
            {
                return new Response
                {
                    Code = 500,
                    Message = ex.Message,
                    Success = false
                };
            }
        }
    }
}
