public class BackgroundCellImpl : EntityImpl, IBackgroundCell
{
    private BackgroundCellType type;

    public BackgroundCellImpl(Vector2D initialPos, BackgroundCellType type) : base(initialPos, false)
    {
        this.type = type;
    }

    public BackgroundCellType getType()
    {
        return this.type;
    }
}