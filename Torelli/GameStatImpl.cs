using System.Collections;

public class GameStatImpl : IGameStat{
    private int coins;
    private List<bool> unlockedSkins = new List<bool>();
    public void addCoins(int collectedCoins)
    {
        coins += collectedCoins;
    }

    public void changeUnlockedSkins(List<bool> unlockedSkins)
    {
        this.unlockedSkins = unlockedSkins;
    }

    public int getCoins()
    {
        return coins;
    }

    public List<bool> getUnlockedSkins()
    {
        return unlockedSkins;
    }

    public void setCoins(int coins)
    {
        this.coins = coins;
    }
}