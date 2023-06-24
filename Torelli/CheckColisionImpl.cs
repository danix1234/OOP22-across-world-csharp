public class CheckCollisionImpl : ICheckCollision
{
    List<BackgroundCellImpl> backgroundCellsList = new List<BackgroundCellImpl>();

    public bool checkFinishLineCollision(Vector2D playerPos)
    {
        return this.backgroundCellsList.Where(background => background.Equals(BackgroundCellType.FINISHLINE))
                                        .Where(finishline => finishline.getPosition().Equals(playerPos))
                                        .Count()!=0;
    }

    public bool checkWallCollision(Vector2D playerPos)
    {
        return playerPos.getX() < 0 || playerPos.getX() >= 15; //15 sarebbe ottenuto dal launcherImpl che ha il numero di celle orizzontali
    }
}