using Controllers;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        private void Start()
        {
            EventManager.RaiseInputEnableEvent(true);
        }
    }
}
