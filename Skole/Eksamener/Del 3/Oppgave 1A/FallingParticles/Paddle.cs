namespace FallingParticles
{
    class Paddle
    {
        public int Position { get; private set; }
        public int Length { get { return shape.Length; } }
        private readonly int moveDistance = 6;
        private readonly string shape = "========";

    public void Initialize()
    {
        var centerX = Console.WindowWidth / 2;
        Position = centerX - (centerX % moveDistance);
    }

    public void Move()
    {
        if (Console.KeyAvailable)
        {
            var key = Console.ReadKey(true);
            var moveLeft = key.Key == ConsoleKey.LeftArrow && Position >= moveDistance;
            var moveRight = key.Key == ConsoleKey.RightArrow && Position < Console.WindowWidth - shape.Length;
            if (moveLeft || moveRight)
            {
                var direction = moveLeft ? -1 : 1;
                Position += direction * 3 * shape.Length / 4;
            }
        }
    }

    public void Draw()
    {
        Console.SetCursorPosition(Position, Console.WindowHeight - 1);
        Console.Write(shape);
    }
}
}