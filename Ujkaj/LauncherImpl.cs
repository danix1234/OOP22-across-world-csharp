    public sealed class LauncherImpl : Launcher
    {
        public static readonly Launcher LAUNCHER = new LauncherImpl();
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
        private readonly Window window = new WindowFactoryImpl().CreateWindow();
        private readonly GameEngine gameEngine = new GameEngineFactoryImpl().CreateGameEngine();
        private readonly GameWorld gameWorld = new GameWorldFactoryImpl().CreateGameWorld();
        private readonly Loader loader = new LoaderImpl();
        private SceneType sceneType = SceneType.MENU;
        private Difficulty difficulty = Difficulty.EASY;

        private LauncherImpl() { }

        public SceneType GetSceneType()
        {
            return sceneType;
        }

        public Scene GetScene()
        {
            return window.Scene;
        }

        public void SetScene(SceneType sceneType)
        {
            this.sceneType = sceneType;
            window.Scene = new SceneFactoryImpl().CreateScene(this.sceneType);
        }

        public Difficulty GetDifficulty()
        {
            return difficulty;
        }

        public void SetDifficulty(Difficulty difficulty)
        {
            this.difficulty = difficulty;
        }

        public void Start()
        {
            SetScene(sceneType);
        }

        public void CloseWindow()
        {
            gameEngine.ForceStop();
            window.Close();
        }

        public InputHandler GetInputHandler(SceneType sceneType)
        {
            return GetScene().GetInputHandler(sceneType);
        }

        public Player GetPlayer()
        {
            return gameWorld.Player;
        }

        public List<BackgroundCell> GetBackgroundCells()
        {
            return gameWorld.BackgroundCells;
        }

        public List<Collectable> GetCollectables()
        {
            return gameWorld.Collectables;
        }

        public List<Obstacle> GetObstacles()
        {
            return gameWorld.Obstacles;
        }

        public Loader GetLoader()
        {
            return new LoaderImpl();
        }

        public void SaveAndCloseWindow()
        {
            loader.SaveStatOnFile(gameWorld.GameStat);
            CloseWindow();
        }

        public void ShowWindow()
        {
            window.Show();
        }

        public void LoadMap()
        {
            gameWorld.LoadMap();
        }

        public GameStat GetGameStat()
        {
            return gameWorld.GameStat;
        }

        public void MovePlayerIfPossible(int x, int y)
        {
            gameWorld.GameLogic.MovementLogic.MovePlayer(x, y);
        }

        public void StartEngine()
        {
            gameEngine.Start();
        }

        public void MoveDynamicObstacles()
        {
            gameWorld.GameLogic.MovementLogic.MoveObstacle();
        }

        public double ConvertCellToPixelPos(Vector2D cellPos)
        {
            return GetObstaclePixelX(cellPos.X * CELL_DIM);
        }

        public Vector2D ConvertPixelToCellPos(double pixelX, int cellY)
        {
            double x = GetActualPixelX(pixelX) / (double)CELL_DIM;
            if (pixelX % CELL_DIM > (CELL_DIM / 2))
            {
                x++;
            }
            if (pixelX < (CELL_DIM / 2))
            {
                x = TRANSLATE_PIXELS ? LauncherImpl.ORIZ_CELL * 2 : x;
            }
            return new Vector2D((int)x, cellY);
        }

        public double GetActualPixelX(double obstaclePixelX)
        {
            return obstaclePixelX + TRANSLATION_TO_SX;
        }

        public double GetObstaclePixelX(double actualPixelX)
        {
            return actualPixelX - TRANSLATION_TO_SX;
        }

        public CheckCollision GetCheckCollision()
        {
            return gameWorld.GameLogic.CollisionChecker;
        }

        public HandlePowerup GetHandlePowerup()
        {
            return gameWorld.GameLogic.PowerupHandler;
        }

        public void RemoveCollectable(Collectable collectable)
        {
            gameWorld.RemoveCollectable(collectable);
        }
    }