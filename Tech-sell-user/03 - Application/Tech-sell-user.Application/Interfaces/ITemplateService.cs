namespace Tech_sell_user.Application.Interfaces
{
    public interface ITemplateService
    {
        string GetTemplateString(string filePath, Dictionary<string, string> keyValues);
    }
}