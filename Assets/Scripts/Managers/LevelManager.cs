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
        }

        private void UnRegisterEvents()
        {
            EventManager.LoadLevel -= LoadLevel;
        }
        
        private void LoadLevel()
        {
            if (_currentLevel != null)
            {
                Destroy(_currentLevel.gameObject);
                _currentLevel = null;
            }
            
            var level = Instantiate(Resources.Load(string.Format("Levels/Level_{0}", GetLevelNumber())), Vector3.zero, Quaternion.identity) as GameObject;
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

        private int GetLevelNumber() => PlayerPrefsManager.GetLevel();

        private void ResetLevel() => PlayerPrefsManager.SetLevel(1);
    }
}
