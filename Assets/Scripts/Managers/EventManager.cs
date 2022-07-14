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
    }
}
