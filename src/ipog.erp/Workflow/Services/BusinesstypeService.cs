using ipog.erp.DataSource.IRepository;
using ipog.erp.Entity;
using ipog.erp.Extension;
using ipog.erp.Mapping;
using ipog.erp.Models;
using ipog.erp.Workflow.IServices;

namespace ipog.erp.Workflow.Services
{
    public class BusinesstypeService : IBusinesstypeService
    {
        private readonly ILogger<BusinesstypeService> _logger;
        private readonly IMapping _mapper;
        private readonly IBusinesstypeRepository _iBusinesstypeRepository;

        public BusinesstypeService(
            ILogger<BusinesstypeService> logger,
            IMapping mapper,
            IBusinesstypeRepository iBusinesstypeRepository
        )
        {
            _logger = logger;
            _mapper = mapper;
            _iBusinesstypeRepository = iBusinesstypeRepository;
        }

        public async Task<GetResponse<GetBusinesstypeModel>> GetById(long id)
        {
            List<Dictionary<string, object>> result = await _iBusinesstypeRepository.GetById(id);
            Businesstype? businesstype = result
                .Select(static row => DataMapperExtensions.MapRowToModel<Businesstype>(row))
                .FirstOrDefault();
            if (businesstype == null)
            {
                return new GetResponse<GetBusinesstypeModel>()
                {
                    Code = 200,
                    Success = true,
                    Message = "No record found",
                };
            }
            GetBusinesstypeModel response = await _mapper.CreateMap<
                GetBusinesstypeModel,
                Businesstype
            >(businesstype);
            return new GetResponse<GetBusinesstypeModel>()
            {
                Code = 200,
                Success = true,
                Message = "Get successfully.",
                Data = response,
            };
        }

        public async Task<CollectionResponse<BusinesstypeModelCollection>> GetAll()
        {
            List<Dictionary<string, object>> result = await _iBusinesstypeRepository.GetAll();
            List<Businesstype> businesstype = result
                .Select(static row => DataMapperExtensions.MapRowToModel<Businesstype>(row))
                .ToList();
            BusinesstypeModelCollection collection = await _mapper.CreateMap<
                BusinesstypeModelCollection,
                List<Businesstype>
            >(businesstype);
            return new CollectionResponse<BusinesstypeModelCollection>()
            {
                Code = 200,
                Success = true,
                Message = "Get successfully.",
                Record = new() { Count = collection.Count, Data = collection },
            };
        }

        public async Task<BusinesstypeModelCollection> GetFilter(PaginationModel paginationModel)
        {
            Pagination pagination = await _mapper.CreateMap<Pagination, PaginationModel>(
                paginationModel
            );
            List<Dictionary<string, object>> result = await _iBusinesstypeRepository.GetFilter(
                pagination
            );
            List<Businesstype> businesstype = result
                .Select(static row => DataMapperExtensions.MapRowToModel<Businesstype>(row))
                .ToList();
            BusinesstypeModelCollection collection = await _mapper.CreateMap<
                BusinesstypeModelCollection,
                List<Businesstype>
            >(businesstype);
            return collection;
        }

        public async Task<Response> Insert(BusinesstypeModel BusinesstypeModel)
        {
            Businesstype businesstype = await _mapper.CreateMap<Businesstype, BusinesstypeModel>(
                BusinesstypeModel
            );
            bool success = await _iBusinesstypeRepository.Insert(businesstype);
            if (success)
            {
                return new Response()
                {
                    Code = 200,
                    Success = true,
                    Message = "Businesstype inserted successfully.",
                };
            }
            return new Response()
            {
                Code = 200,
                Success = false,
                Message = "Businesstype inserted failed.",
            };
        }

        public async Task<string> Update(BusinesstypeModel businesstypeModel)
        {
            Businesstype businesstype = await _mapper.CreateMap<Businesstype, BusinesstypeModel>(
                businesstypeModel
            );
            bool success = await _iBusinesstypeRepository.Update(businesstype);
            if (success)
                return "Businesstype updated successfully.";
            else
                return "Businesstype update failed.";
        }

        public async Task<string> Delete(long id)
        {
            try
            {
                bool deleted = await _iBusinesstypeRepository.Delete(id);
                if (deleted)
                    return "Businesstype deleted successfully.";
                else
                    return "Businesstype not found.";
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
                bool success = await _iBusinesstypeRepository.SetActiveStatus(id);
                if (success)
                    return "Businesstype status updated to active.";
                else
                    return "Businesstype not found.";
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
                bool success = await _iBusinesstypeRepository.SetInActiveStatus(id);
                if (success)
                    return "Businesstype status updated to inactive.";
                else
                    return "Businesstype not found.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
