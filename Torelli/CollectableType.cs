using System;

public class CollectableType
{
    private static CollectableType COIN = new CollectableType(true, false, 1);
    private static CollectableType POWERUP_COIN_MULTIPLIER = new CollectableType(false, true, null);
    private static CollectableType POWERUP_COIN_MAGNET = new CollectableType(false, true, null);
    private static CollectableType POWERUP_IMMORTALITY = new CollectableType(false, true, null);
    private bool coin;
    private bool powerUp;
    private int? value;

    public CollectableType(bool coin, bool powerUp, int? value)
    {
        this.coin=coin;
        this.powerUp=powerUp;
        this.value=value;
    }
    
    public Boolean isCoin()
    {
        return this.coin;
    }
    private Boolean isPowerUp()
    {
        return this.powerUp;
    }
    private int? coinValue()
    {
        return this.value;
    }
}