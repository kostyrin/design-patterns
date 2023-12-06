namespace Mediator;

public class Participant
{
    private readonly Mediator mediator;

    public Participant(Mediator mediator)
    {
        this.mediator = mediator;
        mediator.Alert += Mediator_Alert;
    }

    public int Value { get; set; }
    public void Say(int n)
    {
        mediator.Broadcast(this, n);
    }

    private void Mediator_Alert(object sender, int n)
    {
        if (sender != this)
        {
            Value += n;
        }
    }
}
