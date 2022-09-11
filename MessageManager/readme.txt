The system A (MessageSystem.MessageGenerator) generates messages (MessageSystem.Message) in random way.
That system may generate N messages per second and then be idle for hours.
Every message has its own priority.
System B (MessageSystem.MessageHandler) can process messages in some way, e.g. by sending them to stdout/console.
Message processing logic is very slow, it's limited by 1 message per second.


what could be improved:
1. Extract logging logic to separate logger.
2. Create a new algorithm of creating a random string: to use random.next for understanding string.lenght and for generation char (convert int to char) and concat chars with stringbuilder.
I didn't do it, because the current logic is simplier and I didn't need more.
3. Add another method of processing the messages.