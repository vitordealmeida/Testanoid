using UnityEngine;

public class DoubleBrick : IBrick
{
    private int _hitCount = 2;

    public int Score
    {
        get { return 3; }
    }

    public bool TakeHit()
    {
        return --_hitCount == 0;
    }

    public Color Color
    {
        get { return _hitCount == 2 ? Color.magenta : Color.red; }
    }
}