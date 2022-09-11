using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;

namespace MessageSystem
{
    public class PriorityQueue : IPriorityQueue
    {
        private ConcurrentDictionary<PriorityEnum, ConcurrentQueue<Message>> messagesByPriorityGroups = new ConcurrentDictionary<PriorityEnum, ConcurrentQueue<Message>>();

        public PriorityQueue()
        {
            InitializeMessagesByPriorityGroups();
        }

        public void Enqueue(PriorityEnum priority, Message message)
        {
            if (message == null)
            {
                var exception = new ArgumentNullException("The message doesn't exist", "message");
                throw exception;
            }

            var concreteGroup = GetGroup(priority);
            concreteGroup.Enqueue(message);
        }

        public void Enqueue(PriorityEnum priority, List<Message> messages)
        {
            foreach (var message in messages ?? new List<Message>())
            {
                Enqueue(priority, message);
            }
        }

        public bool TryDequeue(PriorityEnum? priority, [MaybeNullWhen(false)] out Message message)
        {
            message = default;

            if (priority.HasValue)
            {
                var result = TryDequeue(priority.Value, out message);

                return result;
            }

            var priorities = Enum.GetValues<PriorityEnum>();
            foreach (var p in priorities)
            {
                var result = TryDequeue(p, out message);
                if (result)
                {
                    return result;
                }
            }

            return false;
        }

        public bool TryDequeue([MaybeNullWhen(false)] out Message message)
        {
            return TryDequeue(null, out message);
        }

        public int Count()
        {
            var count = 0;
            var priorities = Enum.GetValues<PriorityEnum>();
            foreach (var priority in priorities)
            {
                var concreteGroup = GetGroup(priority);
                count += concreteGroup.Count;
            }

            return count;
        }

        private void InitializeMessagesByPriorityGroups()
        {
            var priorities = Enum.GetValues<PriorityEnum>();
            foreach (var priority in priorities)
            {
                AddEmptyGroup(priority);
            }
        }

        private void AddEmptyGroup(PriorityEnum priority)
        {
            messagesByPriorityGroups.TryAdd(priority, new ConcurrentQueue<Message>());
        }

        private ConcurrentQueue<Message> GetGroup(PriorityEnum priority)
        {
            if (!messagesByPriorityGroups.TryGetValue(priority, out var group))
            {
                var exception = new ArgumentException($"There is no such a value in supported priorities", "priority");
                throw exception;
            }

            return group;
        }
        private bool TryDequeue(PriorityEnum priority, [MaybeNullWhen(false)] out Message message)
        {
            var concreteGroup = GetGroup(priority);
            var result = concreteGroup.TryDequeue(out message);

            return result;
        }
    }
}
