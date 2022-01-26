using UnityEngine;

public class Pocket : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<BallCollisionsController>() != null)
        {
            Destroy(collision.gameObject);
            GameController.Singletone.BallsController.ScoredBall();
        }
        else if (collision.gameObject.GetComponent<CueBall>() != null)
        {
            Destroy(collision.gameObject);
            GameController.Singletone.BallsController.ScoredCueBall();
        }
    }
}
