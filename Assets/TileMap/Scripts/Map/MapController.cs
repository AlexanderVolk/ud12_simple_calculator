using System;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public int Width = 1;
    public int Height = 1;
    public GameObject ResetStrategyHandler;

    private Tile[,] tiles;

    int levelIdx = 0;

    // Start is called before the first frame update
    void Start()
    {
        MapGenerator mapGenerator = this.GetComponent<MapGenerator>();
        tiles = mapGenerator.GenerateGrid(Width, Height);

        //FOR TEST AND DEMO PURPOSES ONLY!
        //InvokeRepeating("NextLevel", 3.0f, 5.0f);
    }

    public void LoadLevel(string name)
    {
        TextAsset textAsset = (TextAsset) Resources.Load(
            string.Format("Levels/{0}", name), typeof(TextAsset));
        Level level = Level.FromJson(textAsset.ToString());
        ResetStrategyHandler.GetComponent<ResetStrategy>().ResetTo(tiles, level.grid);
    }

    //FOR TEST AND DEMO PURPOSES ONLY!
    private void NextLevel()
    {
        TextAsset[] resources = Resources.LoadAll<TextAsset>("Levels");
        TextAsset textAsset = resources[levelIdx];
        //TextAsset textAsset = (TextAsset) Resources.Load("Levels/1_1.json", typeof(TextAsset));
        Level level = Level.FromJson(textAsset.ToString());
        ResetStrategyHandler.GetComponent<ResetStrategy>().ResetTo(tiles, level.grid);
        System.Random random = new System.Random();
        levelIdx = random.Next(9);
    }
}