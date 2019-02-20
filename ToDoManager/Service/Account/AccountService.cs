using ToDoManager.DataModel;
using ToDoManager.Infrastructure;
using ToDoManager.Models;
using ToDoManager.Repository;
using System.Linq;
using Microsoft.Extensions.Options;

namespace ToDoManager.Service
{
    public class AccountService : IAccountService
    {
        private IUnitOfWork _unitOfWork;
        private readonly AppSettings _appSettings;
        private readonly IPasswordGenerator _passwordGenerator;
        private readonly IAccessTokenGenerator _accessTokenGenerator;

        public AccountService(IUnitOfWork unitOfWork, IOptions<AppSettings> appSettings, IPasswordGenerator passwordGenerator,
            IAccessTokenGenerator accessTokenGenerator)
        {
            _unitOfWork = unitOfWork;
            _appSettings = appSettings.Value;
            _accessTokenGenerator = accessTokenGenerator;
            _passwordGenerator = passwordGenerator;
        }

        public LoginResponse Login(LoginModel loginModel)
        {
            string hashedPassword = _passwordGenerator.GenerateHashedPassword(loginModel.Password);

            var loginUser = _unitOfWork.UserRepository.Get(user => user.Email == loginModel.Email).FirstOrDefault();

            if (loginUser != null && _passwordGenerator.Verify(loginUser.Password, loginModel.Password))
            {
                return new LoginResponse
                {
                    Id = loginUser.Id,
                    FullName = loginUser.FullName,
                    Email = loginUser.Email,
                    AccessToken = _accessTokenGenerator.GenerateAccessToken(loginUser)
                };
            }
            return null;
        }

        public void RegiterUser(RegistrationModel registrationModel)
        {
            if (_unitOfWork.UserRepository.Get(item => item.Email == registrationModel.Email).Any())
            {
                throw new System.Exception("User with this Email Id is already registered with us."); //TODO
            }

            Users user = new Users
            {
                Email = registrationModel.Email,
                FullName = registrationModel.FullName,
                Password = _passwordGenerator.GenerateHashedPassword(registrationModel.Password)
            };
            _unitOfWork.UserRepository.Insert(user);
            _unitOfWork.SaveChanges();
        }
    }
}
