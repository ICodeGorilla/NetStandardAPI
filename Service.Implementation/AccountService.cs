using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Service.Contract;
using Service.DTO;
using Repositories.Contract;
using SharedLibraryDatabase;

namespace Service.Implementation
{
    public class AccountService:IAccountService
    {
        private readonly IAccountRepository _repository;
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;

        public AccountService(IAccountRepository repository, IContactRepository contactRepository, IMapper mapper)
        {
            _repository = repository;
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public IEnumerable<AccountDto> GetAll()
        {
            var allAccounts = _repository.GetAll();
            return _mapper.Map<IEnumerable<Account>, IEnumerable<AccountDto>>(allAccounts);
        }

        public AccountDto GetById(int id)
        {
            try
            {
                var account = _repository.GetById(id);
                return _mapper.Map<Account, AccountDto>(account);
            }
            catch
            {
                return null;
            }   
        }

        public ServiceResponse<AccountDto> Save(AccountDto value)
        {
            try
            {
                var mappedAccount = _mapper.Map<AccountDto, Account>(value);
                mappedAccount.LastModified = DateTime.Now;
                mappedAccount.LastModifiedBy = "Admin";

                foreach (var contact in mappedAccount.Contact)
                {
                    contact.LastModified = mappedAccount.LastModified;
                    contact.LastModifiedBy = mappedAccount.LastModifiedBy;
                }
                var savedAccount = _repository.SaveAndCommit(mappedAccount);
                return ServiceResponseFactory.CreateSuccessResponse(_mapper.Map<Account, AccountDto>(savedAccount));
            }
            catch (DbUpdateException e)
            {
                return ServiceResponseFactory.CreateFailedResponse<AccountDto>(e);
            }

        }

        public ServiceResponse<string> Delete(int id)
        {
            try
            {
                _contactRepository.DeleteAndCommit(x => x.AccountId == id);
                _repository.DeleteAndCommit(x => x.AccountId == id);
                return ServiceResponseFactory.CreateSuccessResponse("Deleted the account");
            }
            catch (DbUpdateException e)
            {
                return ServiceResponseFactory.CreateFailedResponse<string>(e);
            }
        }
    }
}
