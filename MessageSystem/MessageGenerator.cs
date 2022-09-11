namespace MessageSystem
{
    public class MessageGenerator
    {
        public const int MessageGenerationTime = 1000;
        public const int DefaultMessageCount = 10;
        public const int DefaultDelay = 10000000;
        
        private readonly IPriorityQueue messages;
        private readonly int messageCount;
        private readonly int delay;

        public delegate void EventHandler(IPriorityQueue queue);
        public event EventHandler? GenerationComplition;

        public MessageGenerator(int messageCount = DefaultMessageCount, int delay = DefaultDelay)
        {
            messages = new PriorityQueue();
            this.messageCount = messageCount;
            this.delay = delay;
        }

        public void CreatePrioritizedMessages()
        {
            using (var cancellationTokenSource = new CancellationTokenSource(MessageGenerationTime))
            {
                var options = new ParallelOptions()
                {
                    CancellationToken = cancellationTokenSource.Token,                    
                };

                try
                {
                    Parallel.For(0, messageCount, options, (i) =>
                    {
                        var message = Message.CreateRandom();
                        var priority = Helper.GetRandomPriority();
                        messages.Enqueue(priority, message);

                        Console.WriteLine($"Creating message with priority: {priority}, text: {message.Text}.");
                    });
                }
                catch (OperationCanceledException e)
                {
                    Console.WriteLine($"Message generation finished by timeout: {e.Message}");
                }
                catch (AggregateException e)
                {
                    Console.WriteLine($"Something's wrong: {e.Message}");
                }
                finally
                {
                    cancellationTokenSource.Dispose();
                }
            }

            OnGenerationComplition();
        }

        public Task SleepAsync()
        {
            return Task.Delay(delay);
        }

        private void OnGenerationComplition()
        {
            EventHandler? temp = GenerationComplition;
            if (temp != null)
            {
                temp(messages);
            }
        }
    }
}
