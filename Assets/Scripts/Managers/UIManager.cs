using UnityEngine;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private UIMainMenu _uIMainMenu;
        [SerializeField] private UIHUD _uIHUD;
        [SerializeField] private UIWin _uIWin;
        [SerializeField] private UILose _uILose;
    
        private void OnEnable() => RegisterEvents();

        private void OnDisable() => UnRegisterEvents();

        private void RegisterEvents() => EventManager.OnUIChange += ShowScreen;

        private void UnRegisterEvents() => EventManager.OnUIChange -= ShowScreen;

        private void Start() => ShowScreen(Const.UIs.MainMenu);

        private void ShowScreen(Const.UIs uIs)
        {
            CloseAllScreens();

            switch (uIs)
            {
                case Const.UIs.MainMenu:
                    _uIMainMenu.gameObject.SetActive(true);
                    break;
                case Const.UIs.HUD:
                    _uIHUD.gameObject.SetActive(true);
                    break;
                case Const.UIs.Win:
                    _uIWin.gameObject.SetActive(true);
                    break;
                case Const.UIs.Lose:
                    _uILose.gameObject.SetActive(true);
                    break;
                default:
                    break;
            }
        }

        private void CloseAllScreens()
        {
            _uIMainMenu.gameObject.SetActive(false);
            _uIHUD.gameObject.SetActive(false);
            _uIWin.gameObject.SetActive(false);
            _uILose.gameObject.SetActive(false);
        }
    }
}
