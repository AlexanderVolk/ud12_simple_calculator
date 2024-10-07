using UnityEngine;

public abstract class MapGenerator : MonoBehaviour
{
    public abstract Tile[,] GenerateGrid(int width, int height);

    protected Tile InstantiateTile(int x, int y, Vector3 position)
    {
        GameObject tileGO = Instantiate(getTilePrefab());
        tileGO.transform.parent = transform;
        tileGO.transform.localPosition = position;
        Tile tile = tileGO.GetComponent<Tile>();
        tileGO.name = "tile: " + x + ", " + y;
        tile.coord = new Tile.Coord(x, y);
        tile.Reset(-1);
        return tile;
    }

    protected abstract GameObject getTilePrefab();
}