using System.Collections.Generic;
using System.Linq;


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

    public List<Coordinates> ResetCoordinates() {
        var minorX = Coordinates.OrderBy(c => c.X).First().X;
        var minorY = Coordinates.OrderBy(c => c.Y).First().Y;
            
        return Coordinates.Select(coor =>  new Coordinates(coor.X - minorX, coor.Y - minorY)).ToList();
    }
}
