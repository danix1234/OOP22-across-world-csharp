    public class ShopScene : AbstractScene
    {
        private const int PANEL_BACKGROUND_RED = 40;
        private const int PANEL_BACKGROUND_GREEN = 40;
        private const int PANEL_BACKGROUND_BLUE = 40;
        private const int COINS_FONT_SIZE = 20;
        private const int TITLE_FONT_SIZE = 50;
        private const int WHITE_RED = 255;
        private const int WHITE_GREEN = 255;
        private const int WHITE_BLUE = 255;
        private const int FONT_SIZE = 20;
        private const int BUTTON_WIDTH = 200;
        private const int BUTTON_HEIGHT = 70;
        private const int SKIN_SIZE = 300;
        private const string FONT_NAME = "Arial";
        private const int SKIN_PRICE = 25;
        private const int COIN_SIZE = 30;
        private static readonly string PRICE_LABEL = "Skin Price: " + SKIN_PRICE;
        private const int SCROLL_INCREMENT = 50;

        private readonly Launcher launcher = LauncherImpl.LAUNCHER;
        private readonly Random random = new Random();
        private Panel panel;
        private readonly List<Button> skinButtons = new List<Button>();
        private Label coinsLabel;

        public ShopScene()
        {
            InitHead();
            InitBody();
            InitFooter();
            SetPanel(this.panel);
        }

        private void InitHead()
        {
            this.panel = new Panel();
            this.panel.Layout = new BorderLayout();
            this.panel.BackColor = Color.FromArgb(PANEL_BACKGROUND_RED, PANEL_BACKGROUND_GREEN, PANEL_BACKGROUND_BLUE);

            Panel head = new Panel();
            head.Layout = new BorderLayout();
            head.BackColor = Color.FromArgb(PANEL_BACKGROUND_RED, PANEL_BACKGROUND_GREEN, PANEL_BACKGROUND_BLUE);

            Label titleLabel = new Label("SHOP");
            titleLabel.ForeColor = Color.Yellow;
            titleLabel.Font = new Font(FONT_NAME, TITLE_FONT_SIZE, FontStyle.Bold);
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            head.Controls.Add(titleLabel, BorderLayout.CENTER);

            Image coinImage = LauncherImpl.LAUNCHER.GetLoader().GetCollectablesSprites(CollectableType.COIN)[0];
            Image scaledCoinImage = new Bitmap(coinImage, new Size(COIN_SIZE, COIN_SIZE));

            coinsLabel = new Label();
            coinsLabel.Text = "Money: " + launcher.GetGameStat().GetCoins();
            coinsLabel.Image = scaledCoinImage;
            coinsLabel.ImageAlign = ContentAlignment.MiddleLeft;
            coinsLabel.ForeColor = Color.Green;
            coinsLabel.Font = new Font(FONT_NAME, COINS_FONT_SIZE, FontStyle.Bold);
            head.Controls.Add(coinsLabel, BorderLayout.LINE_END);

            Label priceLabel = new Label();
            priceLabel.Text = PRICE_LABEL;
            priceLabel.ForeColor = Color.Green;
            priceLabel.Font = new Font(FONT_NAME, COINS_FONT_SIZE, FontStyle.Bold);
            priceLabel.Image = scaledCoinImage;
            priceLabel.ImageAlign = ContentAlignment.MiddleLeft;
            head.Controls.Add(priceLabel, BorderLayout.LINE_START);

            this.panel.Controls.Add(head, BorderLayout.PAGE_START);
        }

        private void InitBody()
        {
            Panel body = new Panel(new GridBagLayout());
            body.BackColor = Color.FromArgb(PANEL_BACKGROUND_RED, PANEL_BACKGROUND_GREEN, PANEL_BACKGROUND_BLUE);

            ScrollPane skinPane = new ScrollPane();
            skinPane.HorizontalScrollBarPolicy = ScrollPaneConstants.HORIZONTAL_SCROLLBAR_AS_NEEDED;
            skinPane.BackColor = Color.FromArgb(PANEL_BACKGROUND_RED, PANEL_BACKGROUND_GREEN, PANEL_BACKGROUND_BLUE);
            skinPane.Border = null;
            skinPane.HorizontalScrollBar.UnitIncrement = SCROLL_INCREMENT;
            skinPane.VerticalScrollBar.UnitIncrement = SCROLL_INCREMENT;

            List<Image> playerSprites = LauncherImpl.LAUNCHER.GetLoader().GetPlayerSprites();
            foreach (Image img in playerSprites)
            {
                if (playerSprites.IndexOf(img) >= launcher.GetGameStat().GetUnlockedSkins().Count)
                {
                    break;
                }
                body.Controls.Add(CreateSkinButton(img, playerSprites.IndexOf(img)));
            }

            this.panel.Controls.Add(skinPane, BorderLayout.CENTER);
        }

        private void InitFooter()
        {
            Panel footer = new Panel(new BorderLayout());
            footer.BackColor = Color.FromArgb(PANEL_BACKGROUND_RED, PANEL_BACKGROUND_GREEN, PANEL_BACKGROUND_BLUE);

            Button exitButton = new Button("EXIT");
            exitButton.FlatStyle = FlatStyle.Flat;
            exitButton.BackColor = Color.FromArgb(WHITE_RED, WHITE_GREEN, WHITE_BLUE);
            exitButton.ForeColor = Color.Red;
            exitButton.Font = new Font(FONT_NAME, FONT_SIZE, FontStyle.Bold);
            exitButton.Size = new Size(BUTTON_WIDTH, BUTTON_HEIGHT);
            exitButton.Click += (sender, e) => GetInputHandler(SceneType.SHOP).ExecuteAction(Action.CHANGE_SCENE_TO_MENU);
            footer.Controls.Add(exitButton, BorderLayout.LINE_START);

            Button randomButton = new Button("BUY RANDOM");
            randomButton.FlatStyle = FlatStyle.Flat;
            randomButton.BackColor = Color.FromArgb(WHITE_RED, WHITE_GREEN, WHITE_BLUE);
            randomButton.ForeColor = Color.Black;
            randomButton.Font = new Font(FONT_NAME, FONT_SIZE, FontStyle.Bold);
            randomButton.Size = new Size(BUTTON_WIDTH, BUTTON_HEIGHT);
            randomButton.Click += (sender, e) =>
            {
                if (HasEnoughCoins())
                {
                    PurchaseRandomSkin();
                }
                else
                {
                    ShowMessage("Not enough coins!");
                }
            };
            footer.Controls.Add(randomButton, BorderLayout.LINE_END);

            this.panel.Controls.Add(footer, BorderLayout.PAGE_END);
        }

        private Button CreateSkinButton(Image image, int skinIndex)
        {
            Button button = new Button();
            button.Size = new Size(SKIN_SIZE, SKIN_SIZE);

            Image scaledImage = new Bitmap(image, new Size(SKIN_SIZE, SKIN_SIZE));
            button.Image = scaledImage;

            if (launcher.GetGameStat().GetUnlockedSkins()[skinIndex])
            {
                button.Enabled = false;
            }

            skinButtons.Add(button);

            button.Click += (sender, e) =>
            {
                if (HasEnoughCoins())
                {
                    PurchaseSkin(skinIndex);
                }
                else
                {
                    ShowMessage("Not enough coins!");
                }
            };

            return button;
        }

        private bool HasEnoughCoins()
        {
            return launcher.GetGameStat().GetCoins() >= SKIN_PRICE;
        }

        private void PurchaseSkin(int skinIndex)
        {
            launcher.GetGameStat().AddCoins(-SKIN_PRICE);
            SetSkinPurchased(skinIndex);
            coinsLabel.Text = "Coins: " + launcher.GetGameStat().GetCoins();
            ShowMessage("Purchased Skin " + skinIndex + "!");
        }

        private void PurchaseRandomSkin()
        {
            if (HasEnoughCoins())
            {
                List<bool> unlockedSkins = launcher.GetGameStat().GetUnlockedSkins();
                List<int> unlockedIndexes = new List<int>();
                for (int i = 0; i < unlockedSkins.Count; i++)
                {
                    if (!unlockedSkins[i])
                    {
                        unlockedIndexes.Add(i);
                    }
                }

                if (unlockedIndexes.Count > 0)
                {
                    int randomSkin = unlockedIndexes[random.Next(unlockedIndexes.Count)];
                    PurchaseSkin(randomSkin);
                }
                else
                {
                    ShowMessage("No skins available!");
                }
            }
            else
            {
                ShowMessage("Not enough coins!");
            }
        }

        private void SetSkinPurchased(int skinIndex)
        {
            List<bool> unlockedSkins = new List<bool>(launcher.GetGameStat().GetUnlockedSkins());
            unlockedSkins[skinIndex] = true;
            launcher.GetGameStat().ChangeUnlockedSkins(unlockedSkins);
            skinButtons[skinIndex].Enabled = false;
        }

        private void ShowMessage(string message)
        {
            MessageBox.Show(panel, message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void Update()
        {
        }
    }