using Tech_sell_user.Application.Interfaces;

namespace Tech_sell_user.Application.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTimeService()
        {
        }

        public DateTime GetDateTime()
        {
            return DateTime.UtcNow.AddHours(-3);
        }
    }
}