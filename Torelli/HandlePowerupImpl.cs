using System.Timers;

public class HandlePowerupImpl : IHandlePowerup{
    private const int POWERUP_DURATION = 10_000;
    private List<CollectableType> powerupTypeList = new List<CollectableType>();
    private long counter = long.MinValue;
    private long clearId;

    //[MethodImpl(MethodImplOptions.Synchronized)]
    public void addPowerup(CollectableType type)
    {
        this.powerupTypeList.Add(type);
        System.Timers.Timer aTimer = new System.Timers.Timer();
        aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        aTimer.Interval = POWERUP_DURATION;
        clearId = this.getCounter();
        aTimer.Enabled = true;
    }

    private void OnTimedEvent(object? source, ElapsedEventArgs e)
    {
        try{
            if (clearId == getCounter() && powerupTypeList.Count()!=0) {
                            powerupTypeList.RemoveRange(0,1);
                        }
        }catch(ThreadInterruptedException er){
            throw new ThreadStateException(er.ToString());
        }
    }

    public void clearPowerUp()
    {
        throw new NotImplementedException();
    }

    public List<CollectableType> getCurrentPowerUp()
    {
        throw new NotImplementedException();
    }

    private long getCounter() {
        return this.counter;
    }

    private void increaseCounter() {
        this.counter++;
    }
    
}