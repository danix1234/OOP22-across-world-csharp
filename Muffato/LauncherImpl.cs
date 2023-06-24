public class LauncherImpl : ILauncher
{
    public static readonly ILauncher LAUNCHER = new LauncherImpl();
    public static readonly int WIDTH = 1920;
    public static readonly int HEIGHT = 1080;
    public static readonly int ORIZ_CELL = 15;
    public static readonly int VERT_CELL = HEIGHT / (WIDTH / ORIZ_CELL) + 1;
    public static readonly int CELL_DIM = WIDTH / ORIZ_CELL;
    public static readonly int TOP_CELL_DELTA = VERT_CELL / 2;
    public static readonly int BOTTOM_CELL_DELTA = VERT_CELL - TOP_CELL_DELTA - 1;
    public static readonly bool TRANSLATE_PIXELS = true;
    public static readonly bool RANDOMIZE_SPEED = true;
    public static readonly bool REMAIN_PLAYER_ON_TRUNK = true;
    public static readonly bool ENABLE_HITBOX = false;
    private static readonly int TRANSLATION_TO_SX = TRANSLATE_PIXELS ? -CELL_DIM : 0;
    private SceneType _sceneType = SceneType.MENU;
    private Difficulty _difficulty = Difficulty.EASY;

    private LauncherImpl()
    {
    }

    SceneType ILauncher.GetSceneType() => _sceneType;

    IScene ILauncher.GetScene() => throw new NotImplementedException();

    void ILauncher.SetScene(SceneType sceneType)
    {
        _sceneType = sceneType;
    }

    Difficulty ILauncher.GetDifficulty() => _difficulty;

    void ILauncher.SetDifficulty(Difficulty difficulty)
    {
        _difficulty = difficulty;
    }

    void ILauncher.Start()
    {
        Console.WriteLine("starting app!");
    }

    void ILauncher.CloseWindow()
    {
        Console.WriteLine("exiting app!");
    }

    IInputHandler ILauncher.GetInputHandler(SceneType sceneType) => throw new NotImplementedException();

    IPlayer ILauncher.GetPlayer() => throw new NotImplementedException();

    List<IBackgroundCell> ILauncher.GetBackgroundCells() => throw new NotImplementedException();

    List<ICollectable> ILauncher.GetCollectables() => throw new NotImplementedException();

    List<IObstacle> ILauncher.GetObstacles() => throw new NotImplementedException();

    ILoader ILauncher.GetLoader() => throw new NotImplementedException();

    void ILauncher.SaveAndCloseWindow()
    {
        Console.WriteLine("saving and exiting app!");
    }

    void ILauncher.ShowWindow()
    {
        Console.WriteLine("showing Window!");
    }

    void ILauncher.LoadMap()
    {
        Console.WriteLine("loading Map!");
    }

    IGameStat ILauncher.GetGameStat() => throw new NotImplementedException();

    void ILauncher.MovePlayerIfPossible(int x, int y)
    {
        Console.WriteLine("moving player!");
    }

    void ILauncher.StartEngine()
    {
        Console.WriteLine("starting engine!");
    }

    void ILauncher.MoveDynamicObstacles()
    {
        Console.WriteLine("moving dynamic obstacle!");
    }

    double ILauncher.ConvertCellToPixelPos(Tuple<int, int> cellPos)
    {
        return LAUNCHER.GetObstaclePixelX(cellPos.Item1 * CELL_DIM);
    }

    Tuple<int, int> ILauncher.ConvertPixelToCellPos(double pixelX, int cellY)
    {
        double x = LAUNCHER.GetActualPixelX(pixelX) / (double)CELL_DIM;

        // move cell one right if left side of cell is more then half over the cell
        if (pixelX % CELL_DIM > (CELL_DIM / 2))
        {
            x++;
        }

        // move cell to narnia if in the left half of cell zero
        if (pixelX < (CELL_DIM / 2))
        {
            x = TRANSLATE_PIXELS ? LauncherImpl.ORIZ_CELL * 2 : x;
        }
        return new Tuple<int, int>((int)x, cellY);
    }

    double ILauncher.GetActualPixelX(double obstaclePixelX)
    {
        return obstaclePixelX + TRANSLATION_TO_SX;
    }

    double ILauncher.GetObstaclePixelX(double actualPixelX)
    {
        return actualPixelX - TRANSLATION_TO_SX;
    }

    ICheckCollision ILauncher.GetCheckCollision() => throw new NotImplementedException();
    IHandlePowerup ILauncher.GetHandlePowerup() => throw new NotImplementedException();
    void ILauncher.RemoveCollectable(ICollectable collectable)
    {
        Console.WriteLine("removing collectable!");
    }
}
