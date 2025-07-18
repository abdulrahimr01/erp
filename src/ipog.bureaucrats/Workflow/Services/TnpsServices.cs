using ipog.bureaucrats.DataSource.IRepository;
using ipog.bureaucrats.Entity;
using ipog.bureaucrats.Extension;
using ipog.bureaucrats.Mapping;
using ipog.bureaucrats.Models;
using ipog.bureaucrats.Workflow.IServices;

namespace ipog.bureaucrats.Workflow.Services
{
    public class TnpscaboutService : ITnpscaboutService
    {
        private readonly ILogger<TnpscaboutService> _logger;
        private readonly IMapping _mapper;
        private readonly ITnpscaboutRepository _iTnpscaboutRepository;

        public TnpscaboutService(
            ILogger<TnpscaboutService> logger,
            IMapping mapper,
            ITnpscaboutRepository iTnpscaboutRepository
        )
        {
            _logger = logger;
            _mapper = mapper;
            _iTnpscaboutRepository = iTnpscaboutRepository;
        }

        public async Task<GetResponse<GetTnpscaboutModel>> GetById(long id)
        {
            List<Dictionary<string, object>> result = await _iTnpscaboutRepository.GetById(id);
            Tnpscabout? tnpscabout = result
                .Select(static row => DataMapperExtensions.MapRowToModel<Tnpscabout>(row))
                .FirstOrDefault();
            if (tnpscabout == null)
            {
                return new GetResponse<GetTnpscaboutModel>()
                {
                    Code = 200,
                    Success = true,
                    Message = "No record found",
                };
            }
            GetTnpscaboutModel response = await _mapper.CreateMap<GetTnpscaboutModel, Tnpscabout>(
                tnpscabout
            );
            return new GetResponse<GetTnpscaboutModel>()
            {
                Code = 200,
                Success = true,
                Message = "Get successfully.",
                Data = response,
            };
        }

        public async Task<CollectionResponse<TnpscaboutModelCollection>> GetAll()
        {
            List<Dictionary<string, object>> result = await _iTnpscaboutRepository.GetAll();
            List<Tnpscabout> tnpscabout = result
                .Select(static row => DataMapperExtensions.MapRowToModel<Tnpscabout>(row))
                .ToList();
            TnpscaboutModelCollection collection = await _mapper.CreateMap<
                TnpscaboutModelCollection,
                List<Tnpscabout>
            >(tnpscabout);
            return new CollectionResponse<TnpscaboutModelCollection>()
            {
                Code = 200,
                Success = true,
                Message = "Get successfully.",
                Record = new() { Count = collection.Count, Data = collection },
            };
        }

        public async Task<TnpscaboutModelCollection> GetFilter(PaginationModel paginationModel)
        {
            Pagination pagination = await _mapper.CreateMap<Pagination, PaginationModel>(
                paginationModel
            );
            List<Dictionary<string, object>> result = await _iTnpscaboutRepository.GetFilter(
                pagination
            );
            List<Tnpscabout> tnpscabout = result
                .Select(static row => DataMapperExtensions.MapRowToModel<Tnpscabout>(row))
                .ToList();
            TnpscaboutModelCollection collection = await _mapper.CreateMap<
                TnpscaboutModelCollection,
                List<Tnpscabout>
            >(tnpscabout);
            return collection;
        }

        public async Task<Response> Insert(TnpscaboutModel tnpscaboutModel)
        {
            Tnpscabout tnpscabout = await _mapper.CreateMap<Tnpscabout, TnpscaboutModel>(
                tnpscaboutModel
            );
            bool success = await _iTnpscaboutRepository.Insert(tnpscabout);
            if (success)
            {
                return new Response()
                {
                    Code = 200,
                    Success = true,
                    Message = "Tnpscabout inserted successfully.",
                };
            }
            return new Response()
            {
                Code = 200,
                Success = false,
                Message = "Tnpscabout inserted failed.",
            };
        }

        public async Task<string> Update(TnpscaboutModel tnpscaboutModel)
        {
            Tnpscabout tnpscabout = await _mapper.CreateMap<Tnpscabout, TnpscaboutModel>(
                tnpscaboutModel
            );
            bool success = await _iTnpscaboutRepository.Update(tnpscabout);
            if (success)
                return "Tnpscabout updated successfully.";
            else
                return "Tnpscabout update failed.";
        }

        public async Task<string> Delete(long id)
        {
            try
            {
                bool deleted = await _iTnpscaboutRepository.Delete(id);
                if (deleted)
                    return "Tnpscabout deleted successfully.";
                else
                    return "Tnpscabout not found.";
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
                bool success = await _iTnpscaboutRepository.SetActiveStatus(id);
                if (success)
                    return "Tnpscabout status updated to active.";
                else
                    return "Tnpscabout not found.";
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
                bool success = await _iTnpscaboutRepository.SetInActiveStatus(id);
                if (success)
                    return "Tnpscabout status updated to inactive.";
                else
                    return "Tnpscabout not found.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
