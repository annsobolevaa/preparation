using System.Diagnostics.CodeAnalysis;

namespace MessageSystem
{
    public interface IPriorityQueue
    {
        public void Enqueue(PriorityEnum priority, Message message);

        public void Enqueue(PriorityEnum priority, List<Message> messages);

        public bool TryDequeue(PriorityEnum? priority, [MaybeNullWhen(false)] out Message message);

        public bool TryDequeue([MaybeNullWhen(false)] out Message message);

        public int Count();
    }
}
