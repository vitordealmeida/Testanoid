using System;

public class GameInteractor
{
    private static GameInteractor _instance;

    public static GameInteractor Instance
    {
        get { return _instance ?? (_instance = new GameInteractor()); }
    }

    public event Action<uint> LivesChanged;
    public event Action<uint> ScoreChanged;
    public event Action GameFinishingLose;
    public event Action GameFinishingWin;
    public event Action NewRoundStarting;

    private GameData _data;

    private GameInteractor()
    {
    }

    public uint Score
    {
        get { return _data.Score; }
    }

    public void NewGame(uint lives, uint bricks)
    {
        _data = new GameData(lives, bricks);
        if (NewRoundStarting != null) NewRoundStarting();
    }

    public void DestroyBrick(int brickScore)
    {
        _data.Bricks -= 1;
        _data.Score += (uint) brickScore;
        EvaluateScore();
    }

    public void DecreaseLivesCount()
    {
        _data.Lives -= 1;
        EvaluateLives();
    }

    public void SetLives(uint lives)
    {
        _data.Lives = lives;
        EvaluateLives();
    }

    public void SetScore(uint score)
    {
        _data.Score = score;
        EvaluateScore();
    }

    private void EvaluateScore()
    {
        if (ScoreChanged != null) ScoreChanged(_data.Score);
        if (_data.Bricks > 0) return;
        if (GameFinishingWin != null) GameFinishingWin();
    }

    private void EvaluateLives()
    {
        if (LivesChanged != null) LivesChanged(_data.Lives);
        if (_data.Lives == 0)
        {
            if (GameFinishingLose != null) GameFinishingLose();
        }
        else
        {
            if (NewRoundStarting != null) NewRoundStarting();
        }
    }
}