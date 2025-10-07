
//public delegate void BallHitEventHandler(object sender, string message);

class Ball
{
    //  public event BallHitEventHandler BallHit;

    public event EventHandler<string> BallHit;
    public void Hit(string playerName)
    {
        //event
        BallHit?.Invoke(this, $"{playerName}  hit ball!");
    }
}