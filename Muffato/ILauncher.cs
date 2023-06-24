public interface Launcher
{
    SceneType GetSceneType();

    void SetScene(SceneType sceneType);

    void CloseWindow();

    void SaveAndCloseWindow();

    Scene GetScene();

    void ShowWindow();

    double ConvertCellToPixelPos(Tuple<int, int> cellPos);

    Tuple<int, int> ConvertPixelToCellPos(double pixelX, int cellY);

    double GetActualPixelX(double obstaclePixelX);

    double GetObstaclePixelX(double actualPixelX);

    Difficulty GetDifficulty();

    void SetDifficulty(Difficulty difficulty);

    Player GetPlayer();

    List<Obstacle> GetObstacles();

    List<Collectable> GetCollectables();

    List<BackgroundCell> GetBackgroundCells();

    Loader GetLoader();

    void LoadMap();

    GameStat GetGameStat();

    void MovePlayerIfPossible(int x, int y);

    void MoveDynamicObstacles();

    void RemoveCollectable(Collectable collectable);

    void Start();

    InputHandler GetInputHandler(SceneType sceneType);

    void StartEngine();

    CheckCollision GetCheckCollision();

    HandlePowerup GetHandlePowerup();

}
