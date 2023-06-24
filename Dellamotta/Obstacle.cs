public interface Obstacle : Entity{
    ObstacleType GetType();

    double getPixelPosition();

    void movePixelPosition(double x);

    double getSpeed();
}