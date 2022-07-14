using System;
using UnityEngine;

namespace Managers
{
    public class ScoreManager : MonoBehaviour
    {
        private int _totalBalls = 0;
        private int _score = 0;
        private int _ballMissed = 0;
        
        private void OnEnable() => RegisterEvents();

        private void OnDisable() => UnRegisterEvents();

        private void RegisterEvents()
        {
            EventManager.BallsInLevel += UpdateTotalBalls;
            EventManager.OnBallInCup += UpdateScore;
            EventManager.OnBallMissed += BallMissed;
            EventManager.ResetGame += Reset;
        }

        private void UnRegisterEvents()
        {
            EventManager.BallsInLevel -= UpdateTotalBalls;
            EventManager.OnBallInCup -= UpdateScore;
            EventManager.OnBallMissed -= BallMissed;
            EventManager.ResetGame -= Reset;
        }
        
        private void UpdateTotalBalls(int totalBalls)
        {
            _totalBalls = totalBalls;
            EventManager.RaiseUIUpdateScoreEvent(_totalBalls, _score);
        }

        private void UpdateScore()
        {
            _score++;
            EventManager.RaiseUIUpdateScoreEvent(_totalBalls, _score);
            CheckGameEnd();
        }

        private void BallMissed()
        {
            _ballMissed++;
            CheckGameEnd();
        }

        private void CheckGameEnd()
        {
            var balls = _ballMissed + _score; 
            if(balls >= _totalBalls)
                EventManager.RaiseLevelEndEvent(_score>=_totalBalls);
        }

        private void Reset()
        {
            _totalBalls = 0;
            _score = 0;
            _ballMissed = 0;
        }
    }
}
