namespace ClinicaApp.InterfaceService
{
    public interface IUserService
    {
        Task<string> AuthenticateUserAsync(string username, string password);
        Task RegisterUserAsync(string username, string password);
    }
}
