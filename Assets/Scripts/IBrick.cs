using UnityEngine;

public interface IBrick
{
    int Score { get; }

    /// <returns>Returns true if the brick was destroyed, false otherwise</returns>
    bool TakeHit();

    Color Color { get; }
}