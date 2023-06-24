public class ObstacleType{

    // valori non inizializzati
    public static ObstacleType TREE = new ObstacleType(0,0,0,0,false);
    public static ObstacleType BUSH = new ObstacleType(0,0,0,0,false);
    public static ObstacleType FENCE = new ObstacleType(0,0,0,0,false);
    public static ObstacleType STOPLIGHT = new ObstacleType(0,0,0,0,false);
    public static ObstacleType TRANSPARENT_OBSTACLE = new ObstacleType(0,0,0,0,true);
    public static ObstacleType SANDCASTLE = new ObstacleType(0,0,0,0,false);
    public static ObstacleType PALM = new ObstacleType(0,0,0,0,false);
    public static ObstacleType BEACHUMBRELLA = new ObstacleType(0,0,0,0,false);
    public static ObstacleType STARFISH = new ObstacleType(0,0,0,0,false);
    public static ObstacleType CAR_DX = new ObstacleType(0,0,0,0,false);
    public static ObstacleType CAR_SX = new ObstacleType(0,0,0,0,false);
    public static ObstacleType TRAIN_DX = new ObstacleType(0,0,0,0,false);
    public static ObstacleType TRAIN_SX = new ObstacleType(0,0,0,0,false);
    public static ObstacleType WAGON_DX = new ObstacleType(0,0,0,0,false);
    public static ObstacleType WAGON_SX = new ObstacleType(0,0,0,0,false);
    public static ObstacleType TRUNK_START_DX = new ObstacleType(0,0,0,0,true);
    public static ObstacleType TRUNK_DX = new ObstacleType(0,0,0,0,true);
    public static ObstacleType TRUNK_FINISH_DX = new ObstacleType(0,0,0,0,true);
    public static ObstacleType TRUNK_START_SX = new ObstacleType(0,0,0,0,true);
    public static ObstacleType TRUNK_SX = new ObstacleType(0,0,0,0,true);
    public static ObstacleType TRUNK_FINISH_SX = new ObstacleType(0,0,0,0,true);
    public static ObstacleType BIKE_DX = new ObstacleType(0,0,0,0,false);
    public static ObstacleType BIKE_SX = new ObstacleType(0,0,0,0,false);
    public static ObstacleType BEACHMATTRESS_SX = new ObstacleType(0,0,0,0,true);
    public static ObstacleType BEACHMATTRESS_DX = new ObstacleType(0,0,0,0,true);
    public static ObstacleType BALL_SX = new ObstacleType(0,0,0,0,false);
    public static ObstacleType BALL_DX = new ObstacleType(0,0,0,0,false);
    public static ObstacleType FIRETREE = new ObstacleType(0,0,0,0,false);
    public static ObstacleType ROCK_DX = new ObstacleType(0,0,0,0,true);
    public static ObstacleType ROCK_SX = new ObstacleType(0,0,0,0,true);
    public static ObstacleType JET_DX = new ObstacleType(0,0,0,0,false);
    public static ObstacleType JET_SX = new ObstacleType(0,0,0,0,false);
    public static ObstacleType MONSTER_DX = new ObstacleType(0,0,0,0,false);
    public static ObstacleType MONSTER_SX = new ObstacleType(0,0,0,0,false);

    private int wrapAroundDim;
    private double speed;
    private double minSpeed;
    private double maxSpeed;
    private bool walkableOn;

    ObstacleType(double speed, double minSpeed, double maxSpeed,
            int wrapAroundDim, bool walkableOn) {
        this.speed = speed;
        this.wrapAroundDim = wrapAroundDim;
        this.minSpeed = minSpeed;
        this.maxSpeed = maxSpeed;
        this.walkableOn = walkableOn;
    }

    public double getSpeed() {
        return this.speed;
    }

    public bool isMoveable() {
        return this.speed != 0;
    }

    public int getWrapAroundDim() {
        return this.wrapAroundDim;
    }

    public double getMinSpeed() {
        return this.minSpeed;
    }

    public double getMaxSpeed() {
        return this.maxSpeed;
    }

    public bool isWalkable() {
        return this.walkableOn;
    }

}