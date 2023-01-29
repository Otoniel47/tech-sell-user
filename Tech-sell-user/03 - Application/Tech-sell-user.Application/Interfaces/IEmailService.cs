namespace Tech_sell_user.Application.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(string sender, string[] recipients, string bodyOfEmail, string subject);

        Task SendEmailAsync(string[] recipients, string bodyOfEmail, string subject);
    }
}