using UnityEngine;

namespace Managers
{
    public class LevelManager : MonoBehaviour
    {
        private GameObject _currentLevel;
        
        private void OnEnable() => RegisterEvents();

        private void OnDisable() => UnRegisterEvents();

        private void RegisterEvents()
        {
            EventManager.LoadLevel += LoadLevel;
            EventManager.OnLevelEnd += HandleLevelEnd;
        }

        private void UnRegisterEvents()
        {
            EventManager.LoadLevel -= LoadLevel;
            EventManager.OnLevelEnd -= HandleLevelEnd;
        }
        
        private void LoadLevel()
        {
            if (_currentLevel != null)
            {
                Destroy(_currentLevel.gameObject);
                _currentLevel = null;
                EventManager.RaiseResetGameEvent();
            }
            
            _currentLevel = Instantiate(Resources.Load(string.Format("Levels/Level_{0}", GetLevelNumber())), Vector3.zero, Quaternion.identity) as GameObject;
        }

        private void UpdateLevel()
        {
            var currentLevelIndex = PlayerPrefsManager.GetLevel();
            currentLevelIndex++;
            
            if (currentLevelIndex > Const.MAX_LEVELS)
            {
                ResetLevel();
                return;
            }
            
            PlayerPrefsManager.SetLevel(currentLevelIndex);
        }

        private void HandleLevelEnd(bool success)
        {
            if(!success) return;
            
            UpdateLevel();
        }

        private int GetLevelNumber() => PlayerPrefsManager.GetLevel();

        private void ResetLevel() => PlayerPrefsManager.SetLevel(1);
    }
}
