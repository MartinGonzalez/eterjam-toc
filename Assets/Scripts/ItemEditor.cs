using System.Collections.Generic;

public class ItemEditor {
    public List<Coordinates> Coordinates { get; }

    public ItemEditor(List<Coordinates> coordinates) {
        Coordinates = coordinates;
    }

    public bool HasCoordinates(int x, int y) {
        foreach (var coordinate in Coordinates) {
            if (coordinate.X == x && coordinate.Y == y)
                return true;
        }

        return false;
    }
}
