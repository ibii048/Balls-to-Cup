using System;
using Controllers;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        private bool _isLevelLoaded = false;
        private void OnEnable() => RegisterEvents();

        private void OnDisable() => UnRegisterEvents();

        private void RegisterEvents()
        {
            EventManager.StartGame += StartGame;
            EventManager.OnLevelEnd += HandleLevelEnd;
        }

        private void UnRegisterEvents()
        {
            EventManager.StartGame -= StartGame;
            EventManager.OnLevelEnd -= HandleLevelEnd;
        }

        private void Start()
        {
            EventManager.RaiseInputEnableEvent(false);
            LoadLevel();
        }

        private void LoadLevel()
        {
            _isLevelLoaded = true;
            EventManager.RaiseLoadLevelEvent();
        }
        
        private void StartGame()
        {
            if(!_isLevelLoaded) LoadLevel();
            EventManager.RaiseUIChangeEvent(Const.UIs.HUD);
            EventManager.RaiseInputEnableEvent(true);
        }

        private void HandleLevelEnd(bool success)
        {
            _isLevelLoaded = false;
            EventManager.RaiseInputEnableEvent(false);
            if(success)
            {
                EventManager.RaiseUIChangeEvent(Const.UIs.Win);
                return;
            }
            
            EventManager.RaiseUIChangeEvent(Const.UIs.Lose);
        }
    }
}
