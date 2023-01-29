namespace Tech_sell_user.Domain.Utils
{
    public class TechSellUserSettings
    {
        public string ConnectionString { get; set; }

        public string? Secret { get; set; }

        public double TokenExpirationTimeInHours { get; set; }
    }
}