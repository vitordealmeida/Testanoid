using UnityEngine;

public class Death : MonoBehaviour
{
    private GameInteractor _gameInteractor;
    
    private void Start()
    {
        _gameInteractor = GameInteractor.Instance;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _gameInteractor.DecreaseLivesCount();
    }
}