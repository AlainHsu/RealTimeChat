using System;
namespace RealTimeChat.Hubs
{
    public class MessageTemplate
    {
        public string toWhom { get; set; }
        public string fromWhom { get; set; }
        public string message { get; set; }
    }
}
