namespace Angalia.Core.Services
{
    public class MessageFactory
    {
       private MessageFactory(string value) { Value = value; }

        public string Value { get; set; }

        public static MessageFactory DatabaseName => new MessageFactory("AngaDB.db3");
    }
}