
namespace GradeTrackerAPI.Strategies
{
    public interface ILoginStrategy
    {
        Task<LoginResult> Login(string email, string password);
    }
}
