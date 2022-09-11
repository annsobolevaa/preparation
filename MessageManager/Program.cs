using MessageSystem;

MessageHandler handler = new MessageHandler();
MessageGenerator generator = new MessageGenerator();
generator.GenerationComplition += handler.Process;
generator.CreatePrioritizedMessages();
await generator.SleepAsync();
