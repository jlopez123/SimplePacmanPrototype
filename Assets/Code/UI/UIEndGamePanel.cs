using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Code.UI
{
    public class UIEndGamePanel : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private TextMeshProUGUI _endText;
        [SerializeField] private Button _reloadButton;
    
        
        public void ShowPanel(bool win)
        {
            _canvasGroup.alpha = 1;
            _canvasGroup.interactable = true;

            _endText.SetText(win ? "Congratulations!!!" : "GAME OVER :(");
        }
        private void Awake()
        {
            _reloadButton.onClick.AddListener(ReloadLevel);
        
            Hide();
        }
        private void Hide()
        {
            _canvasGroup.alpha = 0f;
            _canvasGroup.interactable = false;
        }

        private void ReloadLevel()
        {
            SceneManager.LoadScene(0);
        }

    }
}