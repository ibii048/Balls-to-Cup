using System;
using UnityEngine;

namespace Managers
{
    public class EventManager : MonoBehaviour
    {
        public static event Action<bool> OnInputEnable = null;
        public static void RaiseInputEnableEvent(bool enable) => OnInputEnable?.Invoke(enable);

        public static event Action<float> OnTouch = null;
        public static void RaiseTouchEvent(float inputValue) => OnTouch?.Invoke(inputValue);
        
        public static event Action<Const.UIs> OnUIChange = null;
        public static void RaiseUIChangeEvent(Const.UIs ui) => OnUIChange?.Invoke(ui);
        
        public static event Action StartGame = null;
        public static void RaiseStartGameEvent() => StartGame?.Invoke();
        
        public static event Action LoadLevel = null;
        public static void RaiseLoadLevelEvent() => LoadLevel?.Invoke();
        
        public static event Action<int> BallsInLevel = null;
        public static void RaiseBallsInLevelEvent(int totalBalls) => BallsInLevel?.Invoke(totalBalls);
        
        public static event Action OnBallInCup = null;
        public static void RaiseBallInCupEvent() => OnBallInCup?.Invoke();
        
        public static event Action OnBallMissed = null;
        public static void RaiseBallMissedEvent() => OnBallMissed?.Invoke();
        
        public static event Action<int,int> OnUIUpdateScore = null;
        public static void RaiseUIUpdateScoreEvent(int totalBalls, int score) => OnUIUpdateScore?.Invoke(totalBalls, score);
        
        public static event Action<bool> OnLevelEnd = null;
        public static void RaiseLevelEndEvent(bool success) => OnLevelEnd?.Invoke(success);
        
        public static event Action ResetGame = null;
        public static void RaiseResetGameEvent() => ResetGame?.Invoke();
        
        
    }
}
