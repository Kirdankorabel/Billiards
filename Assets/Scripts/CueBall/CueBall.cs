using UnityEngine;

public class CueBall : MonoBehaviour
{
    public bool isMove = false;
    public float hitMultiplier = 400;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private CueBallTracker _cueBallTracker;
    private Vector3 _direction;

    public Vector3 Direction { get; set; }

    private void Update()
    {
        if (_rigidbody.velocity.magnitude > 0.1f)
            isMove = true;
        else
        {
            isMove = false;
            _rigidbody.velocity = Vector3.zero;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<BallCollisionsController>() != null)
        {
            var force = _rigidbody.velocity;
            _rigidbody.velocity = force.magnitude / 2 * _direction;
        }
        else if (collision.gameObject.tag == "Wall")
        {
            _direction = CollisionsCalculator.WallsCollision(_direction, _rigidbody, transform.position);
        }
    }

    public void Impact(Vector3 position)
    {
        if (isMove) return;
        _direction = (transform.position - position).normalized;
        _rigidbody.AddForce(_direction * (transform.position - position).magnitude * hitMultiplier);
    }
}

