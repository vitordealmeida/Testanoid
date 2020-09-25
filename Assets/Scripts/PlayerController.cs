using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _velocity;

    private Rigidbody2D _rigidbody2D;
    private bool _isPaused;
    
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
        CenterPosition();
    }

    void Update()
    {
        if (_isPaused)
        {
            _rigidbody2D.velocity = Vector2.zero;
        }
        else
        {
            Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
            _rigidbody2D.velocity = direction * _velocity;
        }
    }

    private void CenterPosition()
    {
        var position = transform.position;
        position = new Vector3(0, position.y, position.z);
        transform.position = position;
    }

    public void PauseMovements()
    {
        _isPaused = true;
    }

    public void ResumeMovements()
    {
        _isPaused = false;
    }
}