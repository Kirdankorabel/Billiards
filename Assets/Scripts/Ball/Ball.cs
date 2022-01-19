using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private LineRenderer _line;
    [SerializeField] private BallCollisionsController _ballCollisionsController;
    private Vector3 _direction;

    public LineRenderer Line => _line;

    private void Start()
    {
        _line.SetPosition(0, transform.position);
        _line.SetPosition(1, transform.position);
    }

    private void Update()
    {
        _line.enabled = false;

        if (_ballCollisionsController.Rigidbody.velocity.magnitude > 0.1f)
            _line.positionCount = 1;
        else
        {
            _ballCollisionsController.Rigidbody.velocity = Vector3.zero;
            _line.SetPosition(0, transform.position);
        }
    }

    public void ShowImpactDirection(Vector3 pos)
    {
        _direction = pos;
        _ballCollisionsController.Direction = _direction;
        _line.enabled = true;
        _line.SetPosition(0, transform.position);
        _line.positionCount = 2;
        _line.SetPosition(1, transform.position + _direction * 2);
    }
}
