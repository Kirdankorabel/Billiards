using UnityEngine;

public class BallCollisionsController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    private Vector3 _direction;

    public Vector3 Direction
    {
        set => _direction = value;
    }

    public Rigidbody Rigidbody => _rigidbody;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<CueBall>() != null)
        {
            var force = collision.relativeVelocity;
            _rigidbody.velocity = force.magnitude / 2 * _direction;
        }
        else if(collision.gameObject.tag == "Wall")
        {
            _direction = CollisionsCalculator.WallsCollision(_direction, _rigidbody, transform.position);
        }
    }
}
