public class Pair<X, Y> {
    private X x;
    private Y y;

    public Pair(X x, Y y) {
        this.x = x;
        this.y = y;
    }

    public X get1() {
        return x;
    }

    public Y get2() {
        return y;
    }
}