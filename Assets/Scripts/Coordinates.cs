public class Coordinates {
    public int X { get; }
    public int Y { get; }

    public Coordinates(int x, int y) {
        X = x;
        Y = y;
    }

    protected bool Equals(Coordinates other) {
        return X == other.X && Y == other.Y;
    }

    public override bool Equals(object obj) {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Coordinates) obj);
    }

    public override int GetHashCode() {
        unchecked {
            return (X * 397) ^ Y;
        }
    }
}