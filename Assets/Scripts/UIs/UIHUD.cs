using Managers;
using TMPro;
using UnityEngine;

namespace UIs
{
    public class UIHUD : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _ballCountText;
        
        private void Awake() => RegisterEvents();

        private void OnDestroy() => UnRegisterEvents();

        private void RegisterEvents()
        {
            EventManager.OnUIUpdateScore += UpdateScore;
        }

        private void UnRegisterEvents()
        {
            EventManager.OnUIUpdateScore -= UpdateScore;
        }

        private void UpdateScore(int totalBalls, int score)
        {
            _ballCountText.text = $"{score}/{totalBalls}";
        }
    }
}
