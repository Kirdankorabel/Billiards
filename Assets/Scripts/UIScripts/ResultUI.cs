using UnityEngine;
using UnityEngine.UI;

public class ResultUI : MonoBehaviour
{
    [SerializeField] private Text _resultText;
    [SerializeField] private Button _acceptButton;

    private void Start()
    {
        this.gameObject.SetActive(true);
        _acceptButton.onClick.AddListener(ExitToMenu);
    }
    public void ShowResult(string result)
        => _resultText.text = result;

    private void ExitToMenu()
    {
        GameController.Singletone.UIController.MenuPanel.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }

}
