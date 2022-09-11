namespace MessageSystem.Test
{
    internal partial class PriorityQueueTest
    {
        private static readonly object[] severalMessagesWithOnePrioritySource = {
            new object[] { new List<Message> { Message.CreateRandom() },
                PriorityEnum.High},
            new object[] { new List<Message> { Message.CreateRandom(), Message.CreateRandom() },
                PriorityEnum.High },
            new object[] { new List<Message> { Message.CreateRandom(), Message.CreateRandom(), Message.CreateRandom() },
                PriorityEnum.High },
            new object[] { new List<Message> { Message.CreateRandom() },
                PriorityEnum.Medium},
            new object[] { new List<Message> { Message.CreateRandom(), Message.CreateRandom() },
                PriorityEnum.Medium },
            new object[] { new List<Message> { Message.CreateRandom(), Message.CreateRandom(), Message.CreateRandom() },
                PriorityEnum.Medium },
            new object[] { new List<Message> { Message.CreateRandom() },
                PriorityEnum.Low},
            new object[] { new List<Message> { Message.CreateRandom(), Message.CreateRandom() },
                PriorityEnum.Low },
            new object[] { new List<Message> { Message.CreateRandom(), Message.CreateRandom(), Message.CreateRandom() },
                PriorityEnum.Low }

        };

        private static readonly object[] severalMessagesWithSeveralPrioritiesSource = {
            new object[] { new Dictionary<PriorityEnum, List<Message>>()
                {
                    { PriorityEnum.High,
                        new List<Message> { Message.CreateRandom() }},
                    { PriorityEnum.Medium,
                        new List<Message> { Message.CreateRandom() }},
                    { PriorityEnum.Low,
                        new List<Message> { Message.CreateRandom() }}
                },
            },
            new object[] { new Dictionary<PriorityEnum, List<Message>>()
                {
                    { PriorityEnum.High,
                        new List<Message> { Message.CreateRandom() }},
                    { PriorityEnum.Low,
                        new List<Message> { Message.CreateRandom() }},
                    { PriorityEnum.Medium,
                        new List<Message> { Message.CreateRandom() }}
                },
            },
            new object[] { new Dictionary<PriorityEnum, List<Message>>()
                {
                    { PriorityEnum.Low,
                        new List<Message> { Message.CreateRandom() }},
                    { PriorityEnum.High,
                        new List<Message> { Message.CreateRandom() }},
                    { PriorityEnum.Medium,
                        new List<Message> { Message.CreateRandom() }}
                },
            },
            new object[] { new Dictionary<PriorityEnum, List<Message>>()
                {
                    { PriorityEnum.Low,
                        new List<Message> { Message.CreateRandom() }},
                    { PriorityEnum.Medium,
                        new List<Message> { Message.CreateRandom() }},
                    { PriorityEnum.High,
                        new List<Message> { Message.CreateRandom() }}
                },
            },
            new object[] { new Dictionary<PriorityEnum, List<Message>>()
                {
                    { PriorityEnum.Medium,
                        new List<Message> { Message.CreateRandom() }},
                    { PriorityEnum.Low,
                        new List<Message> { Message.CreateRandom() }},
                    { PriorityEnum.High,
                        new List<Message> { Message.CreateRandom() }}
                },
            },
            new object[] { new Dictionary<PriorityEnum, List<Message>>()
                {
                    { PriorityEnum.Medium,
                        new List<Message> { Message.CreateRandom() }},
                    { PriorityEnum.High,
                        new List<Message> { Message.CreateRandom() }},
                    { PriorityEnum.Low,
                        new List<Message> { Message.CreateRandom() }}
                },
            },
            new object[] { new Dictionary<PriorityEnum, List<Message>>()
                {
                    { PriorityEnum.High,
                        new List<Message> { Message.CreateRandom(), Message.CreateRandom() }},
                    { PriorityEnum.Medium,
                        new List<Message> { Message.CreateRandom(), Message.CreateRandom() }},
                    { PriorityEnum.Low,
                        new List<Message> { Message.CreateRandom(), Message.CreateRandom() }}
                },
            },
            new object[] { new Dictionary<PriorityEnum, List<Message>>()
                {
                    { PriorityEnum.High,
                        new List<Message> { Message.CreateRandom(), Message.CreateRandom() }},
                    { PriorityEnum.Low,
                        new List<Message> { Message.CreateRandom(), Message.CreateRandom() }},
                    { PriorityEnum.Medium,
                        new List<Message> { Message.CreateRandom(), Message.CreateRandom() }}
                },
            },
            new object[] { new Dictionary<PriorityEnum, List<Message>>()
                {
                    { PriorityEnum.Low,
                        new List<Message> { Message.CreateRandom(), Message.CreateRandom() }},
                    { PriorityEnum.High,
                        new List<Message> { Message.CreateRandom(), Message.CreateRandom() }},
                    { PriorityEnum.Medium,
                        new List<Message> { Message.CreateRandom(), Message.CreateRandom() }}
                },
            },
            new object[] { new Dictionary<PriorityEnum, List<Message>>()
                {
                    { PriorityEnum.Low,
                        new List<Message> { Message.CreateRandom(), Message.CreateRandom() }},
                    { PriorityEnum.Medium,
                        new List<Message> { Message.CreateRandom(), Message.CreateRandom() }},
                    { PriorityEnum.High,
                        new List<Message> { Message.CreateRandom(), Message.CreateRandom() }}
                },
            },
            new object[] { new Dictionary<PriorityEnum, List<Message>>()
                {
                    { PriorityEnum.Medium,
                        new List<Message> { Message.CreateRandom(), Message.CreateRandom() }},
                    { PriorityEnum.Low,
                        new List<Message> { Message.CreateRandom(), Message.CreateRandom() }},
                    { PriorityEnum.High,
                        new List<Message> { Message.CreateRandom(), Message.CreateRandom() }}
                },
            },
            new object[] { new Dictionary<PriorityEnum, List<Message>>()
                {
                    { PriorityEnum.Medium,
                        new List<Message> { Message.CreateRandom(), Message.CreateRandom() }},
                    { PriorityEnum.High,
                        new List<Message> { Message.CreateRandom(), Message.CreateRandom() }},
                    { PriorityEnum.Low,
                        new List<Message> { Message.CreateRandom(), Message.CreateRandom() }}
                },
            },
            new object[] { new Dictionary<PriorityEnum, List<Message>>()
                {
                    { PriorityEnum.High,
                        new List<Message> { Message.CreateRandom(), Message.CreateRandom(), Message.CreateRandom() }},
                    { PriorityEnum.Medium,
                        new List<Message> { Message.CreateRandom(), Message.CreateRandom(), Message.CreateRandom() }},
                    { PriorityEnum.Low,
                        new List<Message> { Message.CreateRandom(), Message.CreateRandom(), Message.CreateRandom() }}
                },
            },
            new object[] { new Dictionary<PriorityEnum, List<Message>>()
                {
                    { PriorityEnum.High,
                        new List<Message> { Message.CreateRandom(), Message.CreateRandom(), Message.CreateRandom() }},
                    { PriorityEnum.Low,
                        new List<Message> { Message.CreateRandom(), Message.CreateRandom(), Message.CreateRandom() }},
                    { PriorityEnum.Medium,
                        new List<Message> { Message.CreateRandom(), Message.CreateRandom(), Message.CreateRandom() }}
                },
            },
            new object[] { new Dictionary<PriorityEnum, List<Message>>()
                {
                    { PriorityEnum.Low,
                        new List<Message> { Message.CreateRandom(), Message.CreateRandom(), Message.CreateRandom() }},
                    { PriorityEnum.High,
                        new List<Message> { Message.CreateRandom(), Message.CreateRandom(), Message.CreateRandom() }},
                    { PriorityEnum.Medium,
                        new List<Message> { Message.CreateRandom(), Message.CreateRandom(), Message.CreateRandom() }}
                },
            },
            new object[] { new Dictionary<PriorityEnum, List<Message>>()
                {
                    { PriorityEnum.Low,
                        new List<Message> { Message.CreateRandom(), Message.CreateRandom(), Message.CreateRandom() }},
                    { PriorityEnum.Medium,
                        new List<Message> { Message.CreateRandom(), Message.CreateRandom(), Message.CreateRandom() }},
                    { PriorityEnum.High,
                        new List<Message> { Message.CreateRandom(), Message.CreateRandom(), Message.CreateRandom() }}
                },
            },
            new object[] { new Dictionary<PriorityEnum, List<Message>>()
                {
                    { PriorityEnum.Medium,
                        new List<Message> { Message.CreateRandom(), Message.CreateRandom(), Message.CreateRandom() }},
                    { PriorityEnum.Low,
                        new List<Message> { Message.CreateRandom(), Message.CreateRandom(), Message.CreateRandom() }},
                    { PriorityEnum.High,
                        new List<Message> { Message.CreateRandom(), Message.CreateRandom(), Message.CreateRandom() }}
                },
            },
            new object[] { new Dictionary<PriorityEnum, List<Message>>()
                {
                    { PriorityEnum.Medium,
                        new List<Message> { Message.CreateRandom(), Message.CreateRandom(), Message.CreateRandom() }},
                    { PriorityEnum.High,
                        new List<Message> { Message.CreateRandom(), Message.CreateRandom(), Message.CreateRandom() }},
                    { PriorityEnum.Low,
                        new List<Message> { Message.CreateRandom(), Message.CreateRandom(), Message.CreateRandom() }}
                },
            },
            new object[] { new Dictionary<PriorityEnum, List<Message>>()
                {
                    { PriorityEnum.High,
                        new List<Message> { Message.CreateRandom(), Message.CreateRandom(), Message.CreateRandom() }},
                    { PriorityEnum.Medium,
                        new List<Message> { Message.CreateRandom(), Message.CreateRandom(), Message.CreateRandom() }}
                },
            },
            new object[] { new Dictionary<PriorityEnum, List<Message>>()
                {
                    { PriorityEnum.High,
                        new List<Message> { Message.CreateRandom(), Message.CreateRandom(), Message.CreateRandom() }},
                    { PriorityEnum.Low,
                        new List<Message> { Message.CreateRandom(), Message.CreateRandom(), Message.CreateRandom() }}
                },
            },
            new object[] { new Dictionary<PriorityEnum, List<Message>>()
                {
                    { PriorityEnum.Low,
                        new List<Message> { Message.CreateRandom(), Message.CreateRandom(), Message.CreateRandom() }},
                    { PriorityEnum.High,
                        new List<Message> { Message.CreateRandom(), Message.CreateRandom(), Message.CreateRandom() }}
                },
            },
            new object[] { new Dictionary<PriorityEnum, List<Message>>()
                {
                    { PriorityEnum.Low,
                        new List<Message> { Message.CreateRandom(), Message.CreateRandom(), Message.CreateRandom() }},
                    { PriorityEnum.Medium,
                        new List<Message> { Message.CreateRandom(), Message.CreateRandom(), Message.CreateRandom() }}
                },
            },
            new object[] { new Dictionary<PriorityEnum, List<Message>>()
                {
                    { PriorityEnum.Medium,
                        new List<Message> { Message.CreateRandom(), Message.CreateRandom(), Message.CreateRandom() }},
                    { PriorityEnum.Low,
                        new List<Message> { Message.CreateRandom(), Message.CreateRandom(), Message.CreateRandom() }}
                },
            },
            new object[] { new Dictionary<PriorityEnum, List<Message>>()
                {
                    { PriorityEnum.Medium,
                        new List<Message> { Message.CreateRandom(), Message.CreateRandom(), Message.CreateRandom() }},
                    { PriorityEnum.High,
                        new List<Message> { Message.CreateRandom(), Message.CreateRandom(), Message.CreateRandom() }}
                },
            },
        };
    }
}
