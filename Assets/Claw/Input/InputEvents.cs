
public class SequenceCompletedEvent : GameEvent {

    private readonly string name;

    public string Name { get { return name; } }

    public SequenceCompletedEvent(string name) {
        this.name = name;
    }
}