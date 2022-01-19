using System;
using UnityEngine;

public class BallsController : MonoBehaviour
{
    public event Action victory;
    public event Action lose;

    private int _ballsCount;

    private void Awake()
        => _ballsCount = 15;

    public void ResetBallsCount()
        => _ballsCount = 15;

    public void ScoredBall()
    {
        _ballsCount--;
        if(_ballsCount == 0)
            victory?.Invoke();
    }

    public void ScoredCueBall() =>
        lose?.Invoke();
}
