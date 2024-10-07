using System.Collections;
using UnityEngine;
using Random = System.Random;

/**
 * Provides methods to reset the grid with tiles.
 */
public abstract class ResetStrategy : MonoBehaviour
{
    public enum NAME
    {
        Spiral,
        Wave
    }

    /**
     * Reset the grid from random point/
     */
    public void ResetTo(Tile[,] grid, int[,] level)
    {
        Random r = new Random();
        Tile randomTile = grid[
            r.Next(0, grid.GetLength(0) - 1),
            r.Next(0, grid.GetLength(1) - 1)
        ];
        ResetTo(randomTile, grid, level);
    }

    /**
     * Reset the grid from the specified point.
     */
    public void ResetTo(Tile startTile, Tile[,] grid, int[,] level)
    {
        ResetToInternal(startTile, grid, level);
    }

    /**
     * Strategy specific way to reset tiles.
     */
    protected abstract void ResetToInternal(Tile startTile, Tile[,] grid, int[,] level);


    protected IEnumerator ResetTile(Tile tile, int[,] level, float delay)
    {
        yield return new WaitForSeconds(delay);
        tile.Reset(level[tile.coord.X, tile.coord.Z]);
    }

    protected float NoEasing(float currentIteration, float startTime, float change, float totalTime)
    {
        return currentIteration * totalTime / change + startTime;
    }
}