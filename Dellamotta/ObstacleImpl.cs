using System.Numerics;

public class ObstacleImpl : Obstacle
{
    EntityImpl entityImpl;
    private ObstacleType type;
    private double speed;
    private double pixelX;

    public ObstacleImpl(Vector2 initialPos, ObstacleType type)
    {
        entityImpl = new EntityImpl(initialPos, type.isMoveable());
        this.type = type;
        this.speed = type.getSpeed();
        this.pixelX = 7; // questo valore andrebbe preso dal laucher
    }
    
    ObstacleType Obstacle.GetType()
    {
        return this.type;
    }

    public double getPixelPosition()
    {
        return this.pixelX;
    }

    public void movePixelPosition(double x)
    {
        this.pixelX = x;
    }

    public double getSpeed()
    {
        return this.speed;
    }

    public Vector2 getPosition()
    {
        return entityImpl.getPosition();
    }

    public bool isMoovable()
    {
        return entityImpl.isMoovable();
    }

    public void move(int x, int y)
    {
        entityImpl.move(x,y);

    }
}