namespace FallingParticles
{
    class Game
    {
        readonly Paddle paddle;
        readonly List<Particle> particles = new List<Particle>();
        int level;
        int score;
        int gameRoundsBetweenSpawn;
        private readonly Random random = new Random();

    public Game()
    {
        paddle = new Paddle();
    }

    public void Run()
    {
        Console.CursorVisible = false;
        Console.WindowWidth = 80;
        while (true)
        {
            Initialize();
            var levelCount = 0;
            var roundCount = 45;
            while (true)
            {
                Draw();
                paddle.Move();
                MoveParticles();
                var hasLostParticle = CheckLostParticle();
                if (hasLostParticle) break;
                if (roundCount >= gameRoundsBetweenSpawn)
                {
                    SpawnParticles();
                    InitGameRoundsBetweenSpawn();
                    roundCount = 0;
                }

                roundCount++;
                levelCount++;
                if (levelCount == 100)
                {
                    levelCount = 0;
                    level++;
                }
                Thread.Sleep(100);
            }
            var text = "Game Over! Press ENTER to restart";
            Console.SetCursorPosition(40 - text.Length / 2, 5);
            Console.WriteLine(text);
            Console.ReadLine();
        }
    }

    void Initialize()
    {
        paddle.Initialize();
        particles.Clear();
        score = 0;
        level = 1;
        InitGameRoundsBetweenSpawn();
    }

    void InitGameRoundsBetweenSpawn()
    {
        gameRoundsBetweenSpawn = 45 / level;
    }

    void Draw()
    {
        Console.Clear();
        Console.SetCursorPosition(60, 0);
        Console.Write($"Score: {score}");
        Console.SetCursorPosition(71, 0);
        Console.Write($"Level: {level}");
        paddle.Draw();

        foreach (var particle in particles)
        {
            particle.Draw();
        }
    }

    void MoveParticles()
    {
        for (var index = particles.Count - 1; index >= 0; index--)
        {
            var particle = particles[index];
            particle.Move();
            if (particle.Y > Console.WindowHeight - 1)
            {
                score++;
                particles.Remove(particle);
            }
        }
    }

    bool CheckLostParticle()
    {
        foreach (var particle in particles)
        {
            if ((particle.X < paddle.Position || particle.X > paddle.Position + paddle.Length)
                && particle.Y == Console.WindowHeight - 1)
            {
                return true;
            }
        }

        return false;
    }

    void SpawnParticles()
    {
        var newParticle = new Particle(random.Next(0, Console.WindowWidth), 0);
        particles.Add(newParticle);
    }
}
}