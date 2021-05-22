using Microsoft.AspNetCore.Components;
using Store_Client.Services.HttpService;
using Store_Client.Services.LocalStorageService;
using Store_Shared.Dto;
using Store_Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Client.Services.AccountService
{
    public class AccountService : IAccountService
    {
        private IHttpService _httpService;
        private NavigationManager _navigationManager;
        private ILocalStorageService _localStorageService;
        private string _userKey = "user";

        public ApplicationUser User { get; private set; }

        public AccountService(
            IHttpService httpService,
            NavigationManager navigationManager,
            ILocalStorageService localStorageService
        )
        {
            _httpService = httpService;
            _navigationManager = navigationManager;
            _localStorageService = localStorageService;
        }

        public async Task Initialize()
        {
            User = await _localStorageService.GetItem<ApplicationUser>(_userKey);
        }

        public async Task Login(TokenRequestModel model)
        {
            User = await _httpService.Post<ApplicationUser>("api/Auth/login", model);
            await _localStorageService.SetItem(_userKey, User);
        }

        public async Task Logout()
        {
            User = null;
            await _localStorageService.RemoveItem(_userKey);
            _navigationManager.NavigateTo("account/login");
        }

        public async Task Register(RegisterModel model)
        {
            await _httpService.Post("api/Auth/register", model);
        }

        public async Task<IList<ApplicationUser>> GetAll()
        {
            return await _httpService.Get<IList<ApplicationUser>>("api/users");
        }

        public async Task<ApplicationUser> GetById(string id)
        {
            return await _httpService.Get<ApplicationUser>($"/users/{id}");
        }

        public async Task Update(string id, EditUserModel model)
        {
            await _httpService.Put($"/users/{id}", model);

            // update stored user if the logged in user updated their own record
            if (id == User.Id)
            {
                // update local storage
                User.FirstName = model.FirstName;
                User.LastName = model.LastName;
                User.UserName = model.UserName;
                await _localStorageService.SetItem(_userKey, User);
            }
        }

        public async Task Delete(string id)
        {
            await _httpService.Delete($"/users/{id}");

            // auto logout if the logged in user deleted their own record
            if (id == User.Id)
                await Logout();
        }
    }

}
