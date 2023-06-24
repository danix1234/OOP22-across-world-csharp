using System.Numerics;

public interface Entity {
    Vector2 getPosition();

    bool isMoovable();

    void move(int x, int y);
}