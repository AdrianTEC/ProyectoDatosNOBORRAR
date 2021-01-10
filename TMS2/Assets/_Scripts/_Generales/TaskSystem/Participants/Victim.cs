using _Scripts.TaskSystem.Tasks;

public class Victim : Participants
{
    public override void Avisar()
    {
        task.TellSomething();
    }

    public override void Interactuar()
    {
        Avisar();
    }

    private void OnDestroy()
    {
        Interactuar();
    }
}