using Managers;
using UnityEngine;

namespace Controllers
{
    public class InputController : MonoBehaviour
    {
        private bool _enable = false;
        
        private void OnEnable() => RegisterEvents();

        private void OnDisable() => UnRegisterEvents();

        private void RegisterEvents() => EventManager.OnInputEnable += InputEnableEvent;

        private void UnRegisterEvents() => EventManager.OnInputEnable -= InputEnableEvent;

        private void InputEnableEvent(bool enable) => _enable = enable;

        private void Update()
        {
            if (!_enable) return;
            
            var inputValue = Input.GetAxis("Mouse X");
            EventManager.RaiseTouchEvent(inputValue);
        }
    }
}
