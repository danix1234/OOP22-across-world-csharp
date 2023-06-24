using System.Numerics;

public class BackgroundCellImpl : BackgroundCell
{
    EntityImpl entityImpl;
    private BackgroundCellType type;

    public BackgroundCellImpl(Vector2 initialPos, BackgroundCellType type)
    {
        entityImpl = new EntityImpl(initialPos, false);
        this.type = type;
    }

    public BackgroundCellType getType()
    {
        return this.type;
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