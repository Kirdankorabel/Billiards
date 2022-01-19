using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _exitButton;

    private void Start()
    {
        _startButton.onClick.AddListener(StartNewGame);
        _exitButton.onClick.AddListener(() => Application.Quit());
    }

    private void StartNewGame()
    {
        this.gameObject.SetActive(false);
        GameController.Singletone.StartNewGame();
    }
}
