    public abstract class AbstractScene : Scene
    {
        private Panel scenePanel;
        private readonly Dictionary<SceneType, InputHandler> inputHandlers = new Dictionary<SceneType, InputHandler>();

        public AbstractScene()
        {
            inputHandlers.Add(SceneType.MENU, new MenuInputHandler());
            inputHandlers.Add(SceneType.SHOP, new ShopInputHandler());
            inputHandlers.Add(SceneType.GAME, new GameInputHandler());
            inputHandlers.Add(SceneType.OVER, new GameOverInputHandler());
            inputHandlers.Add(SceneType.VICTORY, new VictoryInputHandler());
        }

        public Panel GetPanel()
        {
            return scenePanel ?? throw new NullReferenceException("Scene panel is null.");
        }

        public InputHandler GetInputHandler(SceneType sceneType)
        {
            return inputHandlers[sceneType];
        }

        protected void SetPanel(Panel newPanel)
        {
            scenePanel = newPanel;
        }
    }
