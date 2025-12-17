namespace TaskManagement.Services
{
    public class MessageServices : IMessageServices
    {
        private readonly Guid _instanceId;

        public MessageServices()
        {
            _instanceId = Guid.NewGuid();
        }

        public string GetMessage()
        {
            return $"Message from instance {_instanceId}";
        }
    }
}
