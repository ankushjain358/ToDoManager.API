using ToDoManager.Models;

namespace ToDoManager.Service
{
    public interface IAccountService
    {
        LoginResponse Login(LoginModel loginModel);

        void RegiterUser(RegistrationModel registrationModel);
    }
}
