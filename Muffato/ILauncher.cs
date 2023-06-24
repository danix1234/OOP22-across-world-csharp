public interface Launcher
{
    SceneType GetSceneType();

    void SetScene(SceneType sceneType);

    void CloseWindow();

    void SaveAndCloseWindow();

    IScene GetScene();

    void ShowWindow();

    double ConvertCellToPixelPos(Tuple<int, int> cellPos);

    Tuple<int, int> ConvertPixelToCellPos(double pixelX, int cellY);

    double GetActualPixelX(double obstaclePixelX);

    double GetObstaclePixelX(double actualPixelX);

    Difficulty GetDifficulty();

    void SetDifficulty(Difficulty difficulty);

    IPlayer GetPlayer();

    List<IObstacle> GetObstacles();

    List<ICollectable> GetCollectables();

    List<IBackgroundCell> GetBackgroundCells();

    ILoader GetLoader();

    void LoadMap();

    IGameStat GetGameStat();

    void MovePlayerIfPossible(int x, int y);

    void MoveDynamicObstacles();

    void RemoveCollectable(ICollectable collectable);

    void Start();

    IInputHandler GetInputHandler(SceneType sceneType);

    void StartEngine();

    ICheckCollision GetCheckCollision();

    IHandlePowerup GetHandlePowerup();

}
