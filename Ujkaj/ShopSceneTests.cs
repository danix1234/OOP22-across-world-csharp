[TestFixture]
    public class ShopSceneTests
    {
        [Test]
        public void PurchaseSkin_SkinIndexInRange_CoinsDecreased()
        {
            // Arrange
            var shopScene = new ShopScene();
            var launcher = LauncherImpl.LAUNCHER;
            int initialCoins = launcher.GetGameStat().GetCoins();
            int skinIndex = 0;

            // Act
            shopScene.PurchaseSkin(skinIndex);
            int updatedCoins = launcher.GetGameStat().GetCoins();

            // Assert
            Assert.AreEqual(initialCoins - ShopScene.SKIN_PRICE, updatedCoins);
        }

        [Test]
        public void PurchaseSkin_NotEnoughCoins_ShowMessage()
        {
            var shopScene = new ShopScene();
            var launcher = LauncherImpl.LAUNCHER;
            int initialCoins = launcher.GetGameStat().GetCoins();
            int skinIndex = 0;
            launcher.GetGameStat().AddCoins(-initialCoins + ShopScene.SKIN_PRICE - 1);

            shopScene.PurchaseSkin(skinIndex);
            int updatedCoins = launcher.GetGameStat().GetCoins();

            Assert.AreEqual(initialCoins, updatedCoins);
        }

        [Test]
        public void PurchaseRandomSkin_UnlockedSkinsAvailable_SkinPurchased()
        {
            // Arrange
            var shopScene = new ShopScene();
            var launcher = LauncherImpl.LAUNCHER;
            int initialCoins = launcher.GetGameStat().GetCoins();
            var unlockedSkins = new List<bool>() { false, false, true, false };
            launcher.GetGameStat().ChangeUnlockedSkins(unlockedSkins);

            // Act
            shopScene.PurchaseRandomSkin();
            int updatedCoins = launcher.GetGameStat().GetCoins();
            List<bool> updatedUnlockedSkins = launcher.GetGameStat().GetUnlockedSkins();

            // Assert
            Assert.AreEqual(initialCoins - ShopScene.SKIN_PRICE, updatedCoins);
            Assert.IsTrue(updatedUnlockedSkins.Contains(true));
        }

    }
}