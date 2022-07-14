using System;
using Controllers;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        private void OnEnable() => RegisterEvents();

        private void OnDisable() => UnRegisterEvents();

        private void RegisterEvents()
        {
            EventManager.StartGame += StartGame;
        }

        private void UnRegisterEvents()
        {
            EventManager.StartGame -= StartGame;
        }

        private void Start()
        {
            EventManager.RaiseInputEnableEvent(false);
            EventManager.RaiseLoadLevelEvent();
        }
        
        private void StartGame()
        {
            EventManager.RaiseUIChangeEvent(Const.UIs.HUD);
            EventManager.RaiseInputEnableEvent(true);
        }
    }
}
