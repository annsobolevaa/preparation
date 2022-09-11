namespace MessageSystem
{
    public class Message
    {
        public string Text { get; private set; }

        private Message(string text)
        {
            Text = text;
        }

        public static Message CreateRandom()
        {
            var text = GenerateRandomString();
            var newMessage = new Message(text);

            return newMessage;
        }

        private static string GenerateRandomString()
        {
            var random = new Random();
            var randomNumber = random.Next(0, 100);
            var result = $"message_{randomNumber}";

            return result;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
