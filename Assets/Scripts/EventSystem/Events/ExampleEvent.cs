namespace Events
{
    public class ExampleEvent : BaseEvent
    {
        public int someData;

        public ExampleEvent(int _someData)
        {
            someData = _someData;
        }
    }
}