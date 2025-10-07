class Program
{
    static void Main(string[] args)
    {
        Player p11 = new Player("Ahmed");
        Player p12 = new Player("Samaa");
        Player p13 = new Player("Ali");
        Player p14 = new Player("Ahmed");


        Ball b1 = new Ball();

        Referee r1 = new Referee("Referee Nada");
        Referee r2 = new Referee("Referee Sara");
        Referee r3 = new Referee("Referee Nader");

        b1.BallHit += r1.OnBallHit;

        b1.BallHit -= r2.OnBallHit;

        b1.BallHit += r3.OnBallHitWithCondition;

        p11.Strike(b1);
        p12.Strike(b1);
        p13.Strike(b1);
        p14.Strike(b1);

        Console.ReadLine();
    }
}