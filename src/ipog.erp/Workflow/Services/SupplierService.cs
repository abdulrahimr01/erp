using ipog.erp.DataSource.IRepository;
using ipog.erp.Entity;
using ipog.erp.Extension;
using ipog.erp.Mapping;
using ipog.erp.Models;
using ipog.erp.Workflow.IServices;

namespace ipog.erp.Workflow.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ILogger<SupplierService> _logger;
        private readonly IMapping _mapper;
        private readonly ISupplierRepository _iSupplierRepository;

        public SupplierService(
            ILogger<SupplierService> logger,
            IMapping mapper,
            ISupplierRepository iSupplierRepository
        )
        {
            _logger = logger;
            _mapper = mapper;
            _iSupplierRepository = iSupplierRepository;
        }

        public async Task<GetResponse<GetSupplierModel>> GetById(long id)
        {
            List<Dictionary<string, object>> result = await _iSupplierRepository.GetById(id);
            Supplier? supplier = result
                .Select(static row => DataMapperExtensions.MapRowToModel<Supplier>(row))
                .FirstOrDefault();
            if (supplier == null)
            {
                return new GetResponse<GetSupplierModel>()
                {
                    Code = 200,
                    Success = true,
                    Message = "No record found",
                };
            }
            GetSupplierModel response = await _mapper.CreateMap<GetSupplierModel, Supplier>(
                supplier
            );
            return new GetResponse<GetSupplierModel>()
            {
                Code = 200,
                Success = true,
                Message = "Get successfully.",
                Data = response,
            };
        }

        public async Task<CollectionResponse<SupplierModelCollection>> GetAll()
        {
            List<Dictionary<string, object>> result = await _iSupplierRepository.GetAll();
            List<Supplier> supplier = result
                .Select(static row => DataMapperExtensions.MapRowToModel<Supplier>(row))
                .ToList();
            SupplierModelCollection collection = await _mapper.CreateMap<
                SupplierModelCollection,
                List<Supplier>
            >(supplier);
            return new CollectionResponse<SupplierModelCollection>()
            {
                Code = 200,
                Success = true,
                Message = "Get successfully.",
                Record = new() { Count = collection.Count, Data = collection },
            };
        }

        public async Task<SupplierModelCollection> GetFilter(PaginationModel paginationModel)
        {
            Pagination pagination = await _mapper.CreateMap<Pagination, PaginationModel>(
                paginationModel
            );
            List<Dictionary<string, object>> result = await _iSupplierRepository.GetFilter(
                pagination
            );
            List<Supplier> supplier = result
                .Select(static row => DataMapperExtensions.MapRowToModel<Supplier>(row))
                .ToList();
            SupplierModelCollection collection = await _mapper.CreateMap<
                SupplierModelCollection,
                List<Supplier>
            >(supplier);
            return collection;
        }

        public async Task<Response> Insert(SupplierModel supplierModel)
        {
            Supplier supplier = await _mapper.CreateMap<Supplier, SupplierModel>(supplierModel);
            bool success = await _iSupplierRepository.Insert(supplier);
            if (success)
            {
                return new Response()
                {
                    Code = 200,
                    Success = true,
                    Message = "Supplier inserted successfully.",
                };
            }
            return new Response()
            {
                Code = 200,
                Success = false,
                Message = "Supplier inserted failed.",
            };
        }

        public async Task<string> Update(SupplierModel supplierModel)
        {
            Supplier supplier = await _mapper.CreateMap<Supplier, SupplierModel>(supplierModel);
            bool success = await _iSupplierRepository.Update(supplier);
            if (success)
                return "Supplier updated successfully.";
            else
                return "Supplier update failed.";
        }

        public async Task<string> Delete(long id)
        {
            try
            {
                bool deleted = await _iSupplierRepository.Delete(id);
                if (deleted)
                    return "Supplier deleted successfully.";
                else
                    return "Supplier not found.";
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
                bool success = await _iSupplierRepository.SetActiveStatus(id);
                if (success)
                    return "Supplier status updated to active.";
                else
                    return "Supplier not found.";
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
                bool success = await _iSupplierRepository.SetInActiveStatus(id);
                if (success)
                    return "Supplier status updated to inactive.";
                else
                    return "Supplier not found.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
