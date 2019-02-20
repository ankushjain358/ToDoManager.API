using ToDoManager.DataModel;

namespace ToDoManager.Infrastructure
{
    public interface IAccessTokenGenerator
    {
        string GenerateAccessToken(Users user);
    }
}
