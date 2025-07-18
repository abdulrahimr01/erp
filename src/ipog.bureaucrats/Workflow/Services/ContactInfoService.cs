using ipog.bureaucrats.DataSource.IRepository;
using ipog.bureaucrats.Entity;
using ipog.bureaucrats.Extension;
using ipog.bureaucrats.Mapping;
using ipog.bureaucrats.Models;
using ipog.bureaucrats.Workflow.IServices;

namespace ipog.bureaucrats.Workflow.Services
{
    public class ContactInfoService : IContactInfoService
    {
        private readonly ILogger<ContactInfoService> _logger;
        private readonly IMapping _mapper;
        private readonly IContactInfoRepository _iContactInfoRepository;

        public ContactInfoService(
            ILogger<ContactInfoService> logger,
            IMapping mapper,
            IContactInfoRepository iContactInfoRepository
        )
        {
            _logger = logger;
            _mapper = mapper;
            _iContactInfoRepository = iContactInfoRepository;
        }

        public async Task<GetResponse<GetContactInfoModel>> GetById(long id)
        {
            List<Dictionary<string, object>> result = await _iContactInfoRepository.GetById(id);
            ContactInfo? contactinfo = result
                .Select(static row => DataMapperExtensions.MapRowToModel<ContactInfo>(row))
                .FirstOrDefault();
            if (contactinfo == null)
            {
                return new GetResponse<GetContactInfoModel>()
                {
                    Code = 200,
                    Success = true,
                    Message = "No record found",
                };
            }
            GetContactInfoModel response = await _mapper.CreateMap<GetContactInfoModel, ContactInfo>(contactinfo);
            return new GetResponse<GetContactInfoModel>()
            {
                Code = 200,
                Success = true,
                Message = "Get successfully.",
                Data = response,
            };
        }

        public async Task<CollectionResponse<ContactInfoModelCollection>> GetAll()
        {
            List<Dictionary<string, object>> result = await _iContactInfoRepository.GetAll();
            List<ContactInfo> contactinfo = result
                .Select(static row => DataMapperExtensions.MapRowToModel<ContactInfo>(row))
                .ToList();
            ContactInfoModelCollection collection = await _mapper.CreateMap<
                ContactInfoModelCollection,
                List<ContactInfo>
            >(contactinfo);
            return new CollectionResponse<ContactInfoModelCollection>()
            {
                Code = 200,
                Success = true,
                Message = "Get successfully.",
                Record = new() { Count = collection.Count, Data = collection },
            };
        }

        public async Task<ContactInfoModelCollection> GetFilter(PaginationModel paginationModel)
        {
            Pagination pagination = await _mapper.CreateMap<Pagination, PaginationModel>(
                paginationModel
            );
            List<Dictionary<string, object>> result = await _iContactInfoRepository.GetFilter(pagination);
            List<ContactInfo> contactinfo = result
                .Select(static row => DataMapperExtensions.MapRowToModel<ContactInfo>(row))
                .ToList();
            ContactInfoModelCollection collection = await _mapper.CreateMap<
                ContactInfoModelCollection,
                List<ContactInfo>
            >(contactinfo);
            return collection;
        }

        public async Task<Response> Insert(ContactInfoModel contactinfoModel)
        {
            ContactInfo contactinfo = await _mapper.CreateMap<ContactInfo, ContactInfoModel>(contactinfoModel);
            bool success = await _iContactInfoRepository.Insert(contactinfo);
            if (success)
            {
                return new Response()
                {
                    Code = 200,
                    Success = true,
                    Message = "ContactInfo inserted successfully.",
                };
            }
            return new Response()
            {
                Code = 200,
                Success = false,
                Message = "ContactInfo inserted failed.",
            };
        }

        public async Task<string> Update(ContactInfoModel contactinfoModel)
        {
            ContactInfo contactinfo = await _mapper.CreateMap<ContactInfo, ContactInfoModel>(contactinfoModel);
            bool success = await _iContactInfoRepository.Update(contactinfo);
            if (success)
                return "ContactInfo updated successfully.";
            else
                return "ContactInfo update failed.";
        }

        public async Task<string> Delete(long id)
        {
            try
            {
                bool deleted = await _iContactInfoRepository.Delete(id);
                if (deleted)
                    return "ContactInfo deleted successfully.";
                else
                    return "ContactInfo not found.";
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
                bool success = await _iContactInfoRepository.SetActiveStatus(id);
                if (success)
                    return "ContactInfo status updated to active.";
                else
                    return "ContactInfo not found.";
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
                bool success = await _iContactInfoRepository.SetInActiveStatus(id);
                if (success)
                    return "ContactInfo status updated to inactive.";
                else
                    return "ContactInfo not found.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
