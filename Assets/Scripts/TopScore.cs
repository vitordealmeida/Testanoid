using UnityEngine;
using UnityEngine.UI;

public class TopScore : MonoBehaviour
{
    public Text Label;

    private void Awake()
    {
        var n = GameInteractor.Instance.Score;
        Label.text += n.ToString();
    }
}