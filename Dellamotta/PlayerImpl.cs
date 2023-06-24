using System.Numerics;

public class PlayerImpl : Player
{
    EntityImpl entityImpl;
    private int maxDistance;

    public PlayerImpl(Vector2 initialPos)
    {
        entityImpl = new EntityImpl(initialPos, true);
        entityImpl.move((int)initialPos.X, (int)initialPos.Y);
    }

    public int getMaxDistance()
    {
        return maxDistance;
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
        maxDistance = Math.Max(maxDistance, y);
    }
}