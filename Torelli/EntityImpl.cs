public class EntityImpl : IEntity
{
    private Vector2D entityPos;
    private bool movable;

    public EntityImpl(Vector2D initialPos, bool movable) {
        this.entityPos = initialPos;
        this.movable = movable;
    }
    public Vector2D getPosition()
    {
        return entityPos;
    }

    public bool isMovable()
    {
        throw new NotImplementedException();
    }

    public void move(int x, int y)
    {
        throw new NotImplementedException();
    }
}