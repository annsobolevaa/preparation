using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;

namespace MessageSystem.Test
{
    [TestFixture]
    internal partial class PriorityQueueTest
    {
        [Test]
        [TestCase(PriorityEnum.High)]
        [TestCase(PriorityEnum.Medium)]
        [TestCase(PriorityEnum.Low)]
        public void Enqueue_NullMessageWithOnePriority(PriorityEnum priority)
        {
            IPriorityQueue priorityQueue = new PriorityQueue();
            Message message = default;

            Assert.Multiple(() =>
            {
                Assert.Throws<ArgumentNullException>(() => priorityQueue.Enqueue(priority, message));
            });
        }

        [Test]
        [TestCase(PriorityEnum.High)]
        [TestCase(PriorityEnum.Medium)]
        [TestCase(PriorityEnum.Low)]
        public void EnqueueDequeueByPriority_OneMessageWithOnePriority(PriorityEnum priority)
        {
            IPriorityQueue priorityQueue = new PriorityQueue();
            var message = Message.CreateRandom();

            priorityQueue.Enqueue(priority, message);

            Assert.Multiple(() =>
            {
                Assert.That(priorityQueue.TryDequeue(priority, out var extractedMessage), Is.True, "The queue should contain the added message.");
                Assert.That(extractedMessage, Is.Not.Null);
                Assert.That(extractedMessage.Text, Is.EqualTo(message.Text), "The extracted message text should be the same like added message text.");
            });            

            DequeueByPriorityForEmptyQueue(priorityQueue);
        }

        private static void DequeueByPriorityForEmptyQueue(IPriorityQueue priorityQueue)
        {
            var notAddedPriorities = Enum.GetValues(typeof(PriorityEnum))
                .Cast<PriorityEnum>()
                .ToList();

            foreach (var notAddedPriority in notAddedPriorities ?? new List<PriorityEnum>())
            {
                Assert.That(priorityQueue.TryDequeue(notAddedPriority, out var _), Is.False, "The queue shouldn't contain the message.");
            }
        }

        [Test]
        [TestCase(PriorityEnum.High)]
        [TestCase(PriorityEnum.Medium)]
        [TestCase(PriorityEnum.Low)]
        public void EnqueueDequeue_OneMessageWithOnePriority(PriorityEnum priority)
        {
            IPriorityQueue priorityQueue = new PriorityQueue();
            var message = Message.CreateRandom();

            priorityQueue.Enqueue(priority, message);
            Assert.Multiple(() =>
            {
                Assert.That(priorityQueue.TryDequeue(out var extractedMessage), Is.True, "The queue should contain the added message.");
                Assert.That(extractedMessage, Is.Not.Null);
                Assert.That(extractedMessage.Text, Is.EqualTo(message.Text), "The extracted message text should be the same like added message text.");
            });

            DequeueForEmptyQueue(priorityQueue);
        }

        private static void DequeueForEmptyQueue(IPriorityQueue priorityQueue)
        {
            var count = Enum.GetValues(typeof(PriorityEnum)).Length;
            for (int i = 0; i < count; i++)
            {
                Assert.That(priorityQueue.TryDequeue(out var _), Is.False, "The queue shouldn't contain the message.");
            }
        }

        [Test]
        [TestCase(PriorityEnum.High)]
        [TestCase(PriorityEnum.Medium)]
        [TestCase(PriorityEnum.Low)]
        public void Enqueue_NullMessagesCollectionWithOnePriority(PriorityEnum priority)
        {
            IPriorityQueue priorityQueue = new PriorityQueue();
            List<Message> messages = default;

            priorityQueue.Enqueue(priority, messages);

            DequeueByPriorityForEmptyQueue(priorityQueue);
        }

        [Test]
        [TestCase(PriorityEnum.High)]
        [TestCase(PriorityEnum.Medium)]
        [TestCase(PriorityEnum.Low)]
        public void Enqueue_EmptyMessagesCollectionWithOnePriority(PriorityEnum priority)
        {
            IPriorityQueue priorityQueue = new PriorityQueue();
            List<Message> messages = new List<Message>();

            priorityQueue.Enqueue(priority, messages);

            DequeueByPriorityForEmptyQueue(priorityQueue);
        }

        [Test]
        [TestCaseSource(nameof(severalMessagesWithOnePrioritySource))]
        public void EnqueueDequeueByPriority_SeveralMessagesWithOnePriority(List<Message> messages, PriorityEnum priority)
        {
            IPriorityQueue priorityQueue = new PriorityQueue();

            priorityQueue.Enqueue(priority, messages);

            var messagesCount = messages.Count;
            for (var i = 0; i < messagesCount; i++)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(priorityQueue.TryDequeue(priority, out var extractedMessage), Is.True, "The queue should contain the added message.");
                    Assert.That(extractedMessage, Is.Not.Null);
                    Assert.That(messages.Contains(extractedMessage), Is.True);
                });
            }

            DequeueByPriorityForEmptyQueue(priorityQueue);
        }

        [Test]
        [TestCaseSource(nameof(severalMessagesWithOnePrioritySource))]
        public void EnqueueDequeue_SeveralMessagesWithOnePriority(List<Message> messages, PriorityEnum priority)
        {
            IPriorityQueue priorityQueue = new PriorityQueue();

            priorityQueue.Enqueue(priority, messages);

            var messagesCount = messages.Count;
            for (var i = 0; i < messagesCount; i++)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(priorityQueue.TryDequeue(out var extractedMessage), Is.True, "The queue should contain the added message.");
                    Assert.That(extractedMessage, Is.Not.Null);
                    Assert.That(messages.Contains(extractedMessage), Is.True);
                });
            }

            DequeueForEmptyQueue(priorityQueue);
        }

        [Test]
        [TestCaseSource(nameof(severalMessagesWithSeveralPrioritiesSource))]
        public void EnqueueDequeueByPriority_SeveralMessagesWithSeveralPriority(Dictionary<PriorityEnum, List<Message>> messagesByPriority)
        {
            IPriorityQueue priorityQueue = new PriorityQueue();

            foreach (var (priority, messages) in messagesByPriority)
            {
                priorityQueue.Enqueue(priority, messages);
            }

            DequeueAllMessagesInPriorityGroup(messagesByPriority, priorityQueue, PriorityEnum.High, true);
            DequeueAllMessagesInPriorityGroup(messagesByPriority, priorityQueue, PriorityEnum.Medium, true);
            DequeueAllMessagesInPriorityGroup(messagesByPriority, priorityQueue, PriorityEnum.Low, true);

            DequeueByPriorityForEmptyQueue(priorityQueue);
        }

        private void DequeueAllMessagesInPriorityGroup(Dictionary<PriorityEnum, List<Message>> messagesByPriority, IPriorityQueue priorityQueue, PriorityEnum priority, bool useDequeueByPriority)
        {
            if (messagesByPriority.TryGetValue(priority, out var highPriorityMessages))
            {
                var count = highPriorityMessages.Count;
                for (int i = 0; i < count; i++)
                {
                    var actualResult = useDequeueByPriority ?
                        priorityQueue.TryDequeue(priority, out var extractedMessage) :
                        priorityQueue.TryDequeue(out extractedMessage);

                    Assert.Multiple(() =>
                    {
                        Assert.That(actualResult, Is.True, "The queue should contain the added message.");
                        Assert.That(extractedMessage, Is.Not.Null);
                        Assert.That(highPriorityMessages.Contains(extractedMessage), Is.True);
                    });
                }
            }
        }

        [Test]
        [TestCaseSource(nameof(severalMessagesWithSeveralPrioritiesSource))]
        public void EnqueueDequeue_SeveralMessagesWithSeveralPriority(Dictionary<PriorityEnum, List<Message>> messagesByPriority)
        {
            IPriorityQueue priorityQueue = new PriorityQueue();

            foreach (var (priority, messages) in messagesByPriority)
            {
                priorityQueue.Enqueue(priority, messages);
            }

            DequeueAllMessagesInPriorityGroup(messagesByPriority, priorityQueue, PriorityEnum.High, false);
            DequeueAllMessagesInPriorityGroup(messagesByPriority, priorityQueue, PriorityEnum.Medium, false);
            DequeueAllMessagesInPriorityGroup(messagesByPriority, priorityQueue, PriorityEnum.Low, false);

            DequeueForEmptyQueue(priorityQueue);
        }
    }
}