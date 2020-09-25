using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlay : MonoBehaviour
{
    public BallController Ball;
    public PlayerController Player;

    public Text ScoreLabel;
    public Text LivesLabel;
    public Text GetReadyLabel;

    [Header("Game parameters")] public int lives;

    private GameInteractor _gameInteractor;

    private void Start()
    {
        _gameInteractor = GameInteractor.Instance;

        _gameInteractor.LivesChanged += OnGameInteractorOnLivesChanged;
        _gameInteractor.ScoreChanged += OnGameInteractorOnScoreChanged;
        _gameInteractor.GameFinishingWin += OnGameInteractorOnGameFinishingWin;
        _gameInteractor.GameFinishingLose += OnGameInteractorOnGameFinishingLose;
        _gameInteractor.NewRoundStarting += OnGameInteractorNewRoundStarting;

        ScoreLabel.text = "000";
        LivesLabel.text = lives.ToString();
        var bricks = FindObjectsOfType<BrikController>().Length;
        
        _gameInteractor.NewGame((uint) lives, (uint) bricks);
    }

    private void OnDestroy()
    {
        _gameInteractor.LivesChanged -= OnGameInteractorOnLivesChanged;
        _gameInteractor.ScoreChanged -= OnGameInteractorOnScoreChanged;
        _gameInteractor.GameFinishingWin -= OnGameInteractorOnGameFinishingWin;
        _gameInteractor.GameFinishingLose -= OnGameInteractorOnGameFinishingLose;
        _gameInteractor.NewRoundStarting -= OnGameInteractorNewRoundStarting;
    }

    private void OnGameInteractorOnGameFinishingLose()
    {
        SceneManager.LoadScene("Lose");
    }

    private void OnGameInteractorOnGameFinishingWin()
    {
        SceneManager.LoadScene("Win");
    }

    private void OnGameInteractorOnScoreChanged(uint score)
    {
        ScoreLabel.text = score.ToString("D3");
    }

    private void OnGameInteractorOnLivesChanged(uint lives)
    {
        LivesLabel.text = lives.ToString();
    }

    private void OnGameInteractorNewRoundStarting()
    {
        GetReadyLabel.enabled = true;
        Player.PauseMovements();
        StartCoroutine(StartGameWithDelay(3));
    }

    private IEnumerator StartGameWithDelay(float delaySeconds)
    {
        yield return new WaitForSeconds(delaySeconds);

        GetReadyLabel.enabled = false;
        Ball.Kick();
        Player.ResumeMovements();
    }

    private void Update()
    {
#if UNITY_EDITOR //debug commands
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _gameInteractor.SetLives(0);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            _gameInteractor.SetScore(4);
        }
#endif
    }
}