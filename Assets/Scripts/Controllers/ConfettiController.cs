using Managers;
using UnityEngine;

namespace Controllers
{
    public class ConfettiController : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particleSystem;
        
        private void OnEnable() => RegisterEvents();

        private void OnDisable() => UnRegisterEvents();

        private void RegisterEvents()
        {
            EventManager.OnLevelEnd += HandleLevelEnd;
        }

        private void UnRegisterEvents()
        {
            EventManager.OnLevelEnd -= HandleLevelEnd;
        }
        
        private void HandleLevelEnd(bool success)
        {
            if(!success) return;
            
            _particleSystem.Play();
        }
    }
}
