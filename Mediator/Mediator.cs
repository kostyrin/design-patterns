namespace Mediator;

public class Mediator
{
    public void Broadcast(object sender, int n)
    {
        Alert?.Invoke(sender, n);
    }

    public event EventHandler<int> Alert;
}
