class Referee
{
    public string Name { get; set; }
    public Referee(string name)
    {
        Name = name;
    }

    public void OnBallHit(object sender, string message)
    {
        Console.WriteLine($"{Name} watch event: {message}");
    }


    public void OnBallHitWithCondition(object sender, string message)
    {
        if (message.Contains("Ahmed"))
        {
            Console.WriteLine($"{Name} watch event with condition: {message}");
        }
    }
}