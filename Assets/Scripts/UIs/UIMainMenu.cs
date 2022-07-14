using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private Button _playButton;

    private void OnEnable() => RegisterEvents();

    private void OnDisable() => UnRegisterEvents();

    private void RegisterEvents() => _playButton.onClick.AddListener(StartGame);

    private void UnRegisterEvents() => _playButton.onClick.RemoveListener(StartGame);

    private void StartGame() => EventManager.RaiseStartGameEvent();
}
