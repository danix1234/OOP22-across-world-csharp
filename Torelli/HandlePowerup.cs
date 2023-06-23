public interface HandlePowerup{
    public void addPowerup(CollectableType type);
    public List<CollectableType> getCurrentPowerUp();
    public void clearPowerUp();
}