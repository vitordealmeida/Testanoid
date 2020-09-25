using UnityEngine;

public class BallController : MonoBehaviour
{
    public float Speed = 1f;
    private Rigidbody2D _rigidbody2D;

    private GameInteractor _gameInteractor;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

        GameInteractor.Instance.NewRoundStarting += GameInteractorOnNewRoundStarting;
    }

    private void OnDestroy()
    {
        GameInteractor.Instance.NewRoundStarting -= GameInteractorOnNewRoundStarting;
    }

    private void GameInteractorOnNewRoundStarting()
    {
        transform.position = Vector3.zero;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    public void Kick()
    {
        ForceVelocity(new Vector2(Random.Range(.1f, .9f), Random.Range(.1f, .9f)).normalized);
    }

    private void FixedUpdate()
    {
        ForceVelocity(_rigidbody2D.velocity.normalized);
    }

    private void ForceVelocity(Vector2 direction)
    {
        _rigidbody2D.velocity = direction * Speed;
    }
}