public interface ICheckCollision{
    //List<Collectable> checkCollectableCollision(Vector2D playerPos);

    //ObstacleType? checkStaticObstacleCollision(Vector2D playerPos);

    //Obstacle? checkDynamicObstacleCollision(Vector2D playerPos);

    bool checkFinishLineCollision(Vector2D playerPos);

    bool checkWallCollision(Vector2D playerPos);

    //Obstacle? checkTrunkCollision(Vector2D playerPos);
}