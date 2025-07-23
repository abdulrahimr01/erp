using ipog.erp.DataSource.IRepository;
using ipog.erp.Entity;
using ipog.erp.Extension;
using ipog.erp.Mapping;
using ipog.erp.Models;
using ipog.erp.Workflow.IServices;

namespace ipog.erp.Workflow.Services
{
    public class HsnService : IHsnService
    {
        private readonly ILogger<HsnService> _logger;
        private readonly IMapping _mapper;
        private readonly IHsnRepository _iHsnRepository;

        public HsnService(
            ILogger<HsnService> logger,
            IMapping mapper,
            IHsnRepository iHsnRepository
        )
        {
            _logger = logger;
            _mapper = mapper;
            _iHsnRepository = iHsnRepository;
        }

        public async Task<GetResponse<GetHsnModel>> GetById(long id)
        {
            List<Dictionary<string, object>> result = await _iHsnRepository.GetById(id);
            Hsn? hsn = result
                .Select(static row => DataMapperExtensions.MapRowToModel<Hsn>(row))
                .FirstOrDefault();
            if (hsn == null)
            {
                return new GetResponse<GetHsnModel>()
                {
                    Code = 200,
                    Success = true,
                    Message = "No record found",
                };
            }
            GetHsnModel response = await _mapper.CreateMap<GetHsnModel, Hsn>(hsn);
            return new GetResponse<GetHsnModel>()
            {
                Code = 200,
                Success = true,
                Message = "Get successfully.",
                Data = response,
            };
        }

        public async Task<CollectionResponse<HsnModelCollection>> GetAll()
        {
            List<Dictionary<string, object>> result = await _iHsnRepository.GetAll();
            List<Hsn> hsn = result
                .Select(static row => DataMapperExtensions.MapRowToModel<Hsn>(row))
                .ToList();
            HsnModelCollection collection = await _mapper.CreateMap<HsnModelCollection, List<Hsn>>(
                hsn
            );
            return new CollectionResponse<HsnModelCollection>()
            {
                Code = 200,
                Success = true,
                Message = "Get successfully.",
                Record = new() { Count = collection.Count, Data = collection },
            };
        }

        public async Task<HsnModelCollection> GetFilter(PaginationModel paginationModel)
        {
            Pagination pagination = await _mapper.CreateMap<Pagination, PaginationModel>(
                paginationModel
            );
            List<Dictionary<string, object>> result = await _iHsnRepository.GetFilter(pagination);
            List<Hsn> hsn = result
                .Select(static row => DataMapperExtensions.MapRowToModel<Hsn>(row))
                .ToList();
            HsnModelCollection collection = await _mapper.CreateMap<HsnModelCollection, List<Hsn>>(
                hsn
            );
            return collection;
        }

        public async Task<Response> Insert(HsnModel hsnModel)
        {
            Hsn hsn = await _mapper.CreateMap<Hsn, HsnModel>(hsnModel);
            bool success = await _iHsnRepository.Insert(hsn);
            if (success)
            {
                return new Response()
                {
                    Code = 200,
                    Success = true,
                    Message = "Hsn inserted successfully.",
                };
            }
            return new Response()
            {
                Code = 200,
                Success = false,
                Message = "Hsn inserted failed.",
            };
        }

        public async Task<string> Update(HsnModel hsnModel)
        {
            Hsn hsn = await _mapper.CreateMap<Hsn, HsnModel>(hsnModel);
            bool success = await _iHsnRepository.Update(hsn);
            if (success)
                return "Hsn updated successfully.";
            else
                return "Hsn update failed.";
        }

        public async Task<string> Delete(long id)
        {
            try
            {
                bool deleted = await _iHsnRepository.Delete(id);
                if (deleted)
                    return "Hsn deleted successfully.";
                else
                    return "Hsn not found.";
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
                bool success = await _iHsnRepository.SetActiveStatus(id);
                if (success)
                    return "Hsn status updated to active.";
                else
                    return "Hsn not found.";
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
                bool success = await _iHsnRepository.SetInActiveStatus(id);
                if (success)
                    return "Hsn status updated to inactive.";
                else
                    return "Hsn not found.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
