using AutoMapper;
using Service.DTO;
using SharedLibraryDatabase;

namespace SharedLibraryCore
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<AccountDto, Account>();
            CreateMap<Account, AccountDto>();
            CreateMap<Contact, ContactDto>();
            CreateMap<ContactDto, Contact>();
        }
    }
}
