class Player
{
    public string Name { get; set; }

    public Player(string name)
    {
        Name = name;
    }

    public void Strike(Ball ball)
    {
        ball.Hit(Name);
    }

}
