using System.Collections.Generic;

public class SquareTile : Tile
{
    /**
     * Returns list of possible neighbours sorted in clockwise order.
     */
    public override List<Coord> GetNeighbours()
    {
        return new List<Coord>
        {
            GetNeighbour( 0, 1),
            GetNeighbour( 1, 1),
            GetNeighbour( 1, 0),
            GetNeighbour( 1, -1),
            GetNeighbour( 0, -1),
            GetNeighbour(-1, -1),
            GetNeighbour(-1, 0),
            GetNeighbour(-1, 1)
        };
    }

    private Coord GetNeighbour(int offsetX, int offsetY)
    {
        return new Coord(coord.X + offsetX, coord.Z + offsetY);
    }
}