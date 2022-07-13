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
    }
}
