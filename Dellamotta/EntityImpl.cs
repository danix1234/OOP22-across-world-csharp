using System.Numerics;

public class EntityImpl : Entity
{
    private Vector2 entityPos;
    private readonly bool movable; 

    public EntityImpl(Vector2 initialPos, bool movable){
        this.entityPos = initialPos;
        this.movable = movable;
    }

    public Vector2 getPosition()
    {
        return this.entityPos;
    }

    public bool isMoovable()
    {
        return this.movable;
    }

    public void move(int x, int y)
    {
        if(movable){
            Vector2 newPos = new Vector2(x, y);
            this.entityPos = newPos;
        }
    }
}