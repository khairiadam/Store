using Store_Shared.Dto;
using Store_Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Client.Services.AccountService
{
    public interface IAccountService
    {
        ApplicationUser User { get; }
        Task Initialize();
        Task Login(TokenRequestModel model);
        Task Logout();
        Task Register(RegisterModel model);
        Task<IList<ApplicationUser>> GetAll();
        Task<ApplicationUser> GetById(string id);
        Task Update(string id, EditUserModel model);
        Task Delete(string id);
    }
}
