public interface IGameStat {
    int getCoins();

    void setCoins(int coins);

    void addCoins(int collectedCoins);

    List<Boolean> getUnlockedSkins();

    void changeUnlockedSkins(List<Boolean> unlockedSkins);
}
