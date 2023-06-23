using System;

public class CollectableType
{
    private Boolean coin;
    private Boolean powerUp;
    private int value;

    public CollectableType(Boolean coin, Boolean powerUp, int value)
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