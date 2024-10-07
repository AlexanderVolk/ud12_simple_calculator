using System.Collections.Generic;
using System.Linq;

/**
 * TODO: draft reset strategy. Should be similiar to Wave,
 * but should start tile reset one by one, not multiple tiles as in "wave".
 */
public class SpiralResetStrategy : ResetStrategy
{
    protected override void ResetToInternal(Tile startTile, Tile[,] grid, int[,] level)
    {
        bool[,] waveGrid = new bool[level.GetLength(0), level.GetLength(1)];

        List<Tile> waves = new List<Tile>();
        List<Tile> nextWave = new List<Tile>
        {
            startTile
        };
        waveGrid[startTile.coord.X, startTile.coord.Z] = true;
        do
        {
            waves.AddRange(nextWave);
            nextWave = GetNextWave(nextWave, grid, waveGrid);
        } while (nextWave.Count > 0);
        
        for (int i = 0; i < waves.Count; i++)
        {
            StartCoroutine(ResetTile(waves[i], level, NoEasing(i, 0f, waves.Count, 1.5f)));
        }
    }

    private List<Tile> GetNextWave(List<Tile> currentWave, Tile[,] grid, bool[,] waveGrid)
    {
        List<Tile> result = new List<Tile>();
        foreach (Tile currentTile in currentWave)
        {
            List<Tile> neighbours = currentTile.GetNeighbours()
                .Where(coord => coord.X >= 0 && coord.X < waveGrid.GetLength(0) && coord.Z >= 0 && coord.Z < waveGrid.GetLength(1))
                .Select(coord => grid[coord.X, coord.Z])
                .ToList();
            foreach (Tile tile in neighbours)
            {
                if (waveGrid[tile.coord.X, tile.coord.Z] == false)
                {
                    result.Add(tile);
                    waveGrid[tile.coord.X, tile.coord.Z] = true;
                }
            }
        }

        return result;
    }
}