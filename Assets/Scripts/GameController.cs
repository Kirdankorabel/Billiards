using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Singletone { get; set; }
    [SerializeField] private CueBall _cueBallPrefab;
    [SerializeField] private UIController _UIController;
    [SerializeField] private BallsController _BallsController;
    [SerializeField] private BallsCreator _ballsCreator;
    [SerializeField] private TouchTracker _touchTracker;
    private CueBall _cueBall;

    public UIController UIController => _UIController; 
    public BallsController BallsController => _BallsController;
    public TouchTracker TouchTracker => _touchTracker;

    private void Awake()
    {
        Singletone = this;
        _cueBall = Instantiate(_cueBallPrefab);
    }

    private void Start()
    {
        _ballsCreator.InstantiateBalls(new Vector3(5, 0, 0));
        _touchTracker.CueBall = _cueBall;
    }

    public void StartNewGame()
    {
        if (_cueBall != null)
            Destroy(_cueBall.gameObject);
        _ballsCreator.InstantiateBalls(new Vector3(5, 0, 0));
        _cueBall = Instantiate(_cueBallPrefab);
        _touchTracker.CueBall = null;
        _touchTracker.CueBall = _cueBall;
    }
}
