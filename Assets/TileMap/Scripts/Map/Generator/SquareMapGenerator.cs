using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class SquareMapGenerator : MapGenerator
{
    // TODO: get prefab from library, not as comppnent argument
    private float tileOffset = 1.1f;

    public GameObject TileObjectPrefab;
    public override Tile[,] GenerateGrid(int width, int height)
    {
        Tile[,] grid = new Tile[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++) 
            {
                Vector3 position = new Vector3(x * tileOffset, 0, y * tileOffset);
                grid[x, y] = InstantiateTile(x, y, position);
            } 
        }

        return grid;
    }

    protected override GameObject getTilePrefab()
    {
        return TileObjectPrefab;
    }
}