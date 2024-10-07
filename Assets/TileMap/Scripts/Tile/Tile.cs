using System.Collections.Generic;
using UnityEngine;

public abstract class Tile : MonoBehaviour
{
    public Coord coord = new Coord(0, 0);
    
    public bool Disabled = true;
    public abstract List<Coord> GetNeighbours();

    public void Reset(int code)
    {
        bool disabled = code < 0;
        // No need to do anything if tile is already disabled
        if (Disabled && disabled)
        {
            return;
        }

        if (!Disabled && disabled)
        {
            gameObject.GetComponent<Animation>().Play("Spin180Animation");
        }
        else if (Disabled && !disabled)
        {
            gameObject.GetComponent<Animation>().Play("Spin180CAnimation");
        }
        else if (!Disabled && !disabled)
        {
            gameObject.GetComponent<Animation>().Play("Spin360Animation");
        }

        Disabled = disabled;
    }

    public class Coord
    {
        public int X;
        public int Z;

        public Coord(int x, int z)
        {
            X = x;
            Z = z;
        }
    }
}