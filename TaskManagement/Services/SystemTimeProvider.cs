namespace TaskManagement.Services
{
    public class SystemTimeProvider : ISystemTimeProvider
    {
        public DateTime GetCurrentTime()
        {
            return DateTime.UtcNow;
        }
    }
}
