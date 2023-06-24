using System;

public class CollectableType
{
    private bool coin;
    private bool powerUp;
    private int value;

    public CollectableType(bool coin, bool powerUp, int value)
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
    private int coinValue()
    {
        return this.value;
    }
}