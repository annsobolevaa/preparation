namespace MessageSystem
{
    internal static class Helper
    {
        public static PriorityEnum GetRandomPriority()
        {
            var random = new Random();
            return (PriorityEnum)random.Next(Enum.GetNames(typeof(PriorityEnum)).Length);
        }
    }
}
