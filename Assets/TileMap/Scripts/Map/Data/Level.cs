using System;

/**
 * Represents saved state of tiles on the grid.
 */
[System.Serializable]
public class Level
{
    public string name;
    public int[,] grid;

    public static Level FromJson(string jsonString)
    {
        Level level = new Level();
        SimpleJSON.JSONNode rootNode = SimpleJSON.JSON.Parse(jsonString);

        SimpleJSON.JSONArray gridArray = rootNode["grid"].AsArray;
        int[][] parsedGrid = new int[gridArray.Count][];
        for (int i = 0; i < gridArray.Count; i++)
        {
            SimpleJSON.JSONArray array = gridArray[i].AsArray;
            parsedGrid[i] = new int[array.Count];
            for (int j = 0; j < array.Count; j++)
            {
                parsedGrid[i][j] = array[j].AsInt;
            }
        }

        level.grid = new int[parsedGrid.Length, parsedGrid[0].Length];
        for (int i = 0; i < parsedGrid.Length; i++)
        {
            for (int k = 0; k < parsedGrid[0].Length; k++)
            {
                level.grid[i, k] = parsedGrid[i][k];
            }
        }

        level.name = rootNode["name"].Value;

        return level;
    }
}