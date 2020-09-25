using UnityEngine;

public class SimpleBrick : IBrick
{
    public int Score
    {
        get { return 1; }
    }

    public bool TakeHit()
    {
        return true;
    }

    public Color Color
    {
        get { return Color.red; }
    }
}