public interface IEntity {
   
    Vector2D getPosition();

    bool isMovable();

    void move(int x, int y);
}