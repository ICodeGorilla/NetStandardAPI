using Service.DTO;
using System.Collections.Generic;

namespace Service.Contract
{
    public interface IAccountService
    {
        IEnumerable<AccountDto> GetAll();
        AccountDto GetById(int id);
        ServiceResponse<AccountDto> Save(AccountDto value);
        ServiceResponse<string> Delete(int id);
    }
}
