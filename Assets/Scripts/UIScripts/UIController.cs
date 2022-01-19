using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private ResultUI _resultPanel;
    [SerializeField] private MenuUI _menuPanel;

    public MenuUI MenuPanel => _menuPanel;
    public ResultUI ResultPanel => _resultPanel;

    private void Start()
    {        
        GameController.Singletone.BallsController.victory += () => Victory();
        GameController.Singletone.BallsController.lose += () => Lose();
    }

    private void Victory()
    {
        _resultPanel.gameObject.SetActive(true);
        _resultPanel.ShowResult("You Victory");
    }

    private void Lose()
    {
        _resultPanel.gameObject.SetActive(true);
        _resultPanel.ShowResult("You Lose");
    }
}
