namespace FallingParticles
{

class Particle
{
    public float X { get; private set; }
    public float Y { get; private set; }

    public Particle(float x, float y)
    {
        X = x;
        Y = y;
    }

    public void Move()
    {
        Y += 0.5f;
    }

    public void Draw()
    {
        var particleX = (int)Math.Floor(X);
        var particleY = (int)Math.Floor(Y);
        Console.SetCursorPosition(particleX, particleY);
        Console.Write("O");
    }

}
} 