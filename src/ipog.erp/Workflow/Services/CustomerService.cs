using ipog.erp.DataSource.IRepository;
using ipog.erp.Entity;
using ipog.erp.Extension;
using ipog.erp.Mapping;
using ipog.erp.Models;
using ipog.erp.Workflow.IServices;

namespace ipog.erp.Workflow.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ILogger<CustomerService> _logger;
        private readonly IMapping _mapper;
        private readonly ICustomerRepository _iCustomerRepository;

        public CustomerService(
            ILogger<CustomerService> logger,
            IMapping mapper,
            ICustomerRepository iCustomerRepository
        )
        {
            _logger = logger;
            _mapper = mapper;
            _iCustomerRepository = iCustomerRepository;
        }

        public async Task<GetResponse<GetCustomerModel>> GetById(long id)
        {
            List<Dictionary<string, object>> result = await _iCustomerRepository.GetById(id);
            Customer? customers = result
                .Select(static row => DataMapperExtensions.MapRowToModel<Customer>(row))
                .FirstOrDefault();
            if (customers == null)
            {
                return new GetResponse<GetCustomerModel>()
                {
                    Code = 200,
                    Success = true,
                    Message = "No record found",
                };
            }
            GetCustomerModel response = await _mapper.CreateMap<GetCustomerModel, Customer>(
                customers
            );
            return new GetResponse<GetCustomerModel>()
            {
                Code = 200,
                Success = true,
                Message = "Get successfully.",
                Data = response,
            };
        }

        public async Task<CollectionResponse<CustomerModelCollection>> GetAll()
        {
            List<Dictionary<string, object>> result = await _iCustomerRepository.GetAll();
            List<Customer> customers = result
                .Select(static row => DataMapperExtensions.MapRowToModel<Customer>(row))
                .ToList();
            CustomerModelCollection collection = await _mapper.CreateMap<
                CustomerModelCollection,
                List<Customer>
            >(customers);
            return new CollectionResponse<CustomerModelCollection>()
            {
                Code = 200,
                Success = true,
                Message = "Get successfully.",
                Record = new() { Count = collection.Count, Data = collection },
            };
        }

        public async Task<CustomerModelCollection> GetFilter(PaginationModel paginationModel)
        {
            Pagination pagination = await _mapper.CreateMap<Pagination, PaginationModel>(
                paginationModel
            );
            List<Dictionary<string, object>> result = await _iCustomerRepository.GetFilter(
                pagination
            );
            List<Customer> customers = result
                .Select(static row => DataMapperExtensions.MapRowToModel<Customer>(row))
                .ToList();
            CustomerModelCollection collection = await _mapper.CreateMap<
                CustomerModelCollection,
                List<Customer>
            >(customers);
            return collection;
        }

        public async Task<Response> Insert(CustomerModel customerModel)
        {
            Customer customer = await _mapper.CreateMap<Customer, CustomerModel>(customerModel);
            bool success = await _iCustomerRepository.Insert(customer);
            if (success)
            {
                return new Response()
                {
                    Code = 200,
                    Success = true,
                    Message = "Customer inserted successfully.",
                };
            }
            return new Response()
            {
                Code = 200,
                Success = false,
                Message = "Customer inserted failed.",
            };
        }

        public async Task<string> Update(CustomerModel customerModel)
        {
            Customer customer = await _mapper.CreateMap<Customer, CustomerModel>(customerModel);
            bool success = await _iCustomerRepository.Update(customer);
            if (success)
                return "Customer updated successfully.";
            else
                return "Customer update failed.";
        }

        public async Task<string> Delete(long id)
        {
            try
            {
                bool deleted = await _iCustomerRepository.Delete(id);
                if (deleted)
                    return "Customer deleted successfully.";
                else
                    return "Customer not found.";
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
                bool success = await _iCustomerRepository.SetActiveStatus(id);
                if (success)
                    return "Customer status updated to active.";
                else
                    return "Customer not found.";
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
                bool success = await _iCustomerRepository.SetInActiveStatus(id);
                if (success)
                    return "Customer status updated to inactive.";
                else
                    return "Customer not found.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
