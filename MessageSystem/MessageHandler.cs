namespace MessageSystem
{
    public class MessageHandler
    {
        public const int MessageProcessingTime = 1000;

        private const int EmulationWorkTime = 1000;

        public void Process(IPriorityQueue messages)
        {
            var count = messages.Count();

            Parallel.For(0, count, (i) =>
            {
                using (var cancellationTokenSource = new CancellationTokenSource(MessageProcessingTime))
                {
                    var token = cancellationTokenSource.Token;
                    var task = Task.Factory.StartNew(() =>
                    {
                        Process(messages, token);
                    }, token);

                    task.Wait();
                }
            });
        }

        protected virtual void Process(IPriorityQueue messages, CancellationToken token)
        {
            if (messages.TryDequeue(out var message))
            {
                Console.WriteLine($"Start process {message}");
                while (!token.IsCancellationRequested)
                {
                    Task.Delay(EmulationWorkTime).Wait();
                    Console.WriteLine($"Long process {message}");
                }
                Console.WriteLine($"Finish process {message}");
            }
        }
    }
}
