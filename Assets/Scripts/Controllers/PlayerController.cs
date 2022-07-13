using Managers;
using UnityEngine;

namespace Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _speed = 100.0f;
        
        private float _rotation = 0.0f;
    
        private void OnEnable() => RegisterEvents();

        private void OnDisable() => UnRegisterEvents();

        private void RegisterEvents() => EventManager.OnTouch += OnTouchEvent;

        private void UnRegisterEvents() => EventManager.OnTouch -= OnTouchEvent;

        private void OnTouchEvent(float inputValue) => UpdatePlayerRotation(inputValue);

        private void UpdatePlayerRotation(float inputValue)
        {
            _rotation -= inputValue * _speed * Time.deltaTime;
            transform.eulerAngles = new Vector3(0.0f, 0.0f, _rotation);
        }
    }
}
