using UnityEngine;

public class Pocket : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ball(Clone)")
        {
            Destroy(collision.gameObject);
            GameController.Singletone.BallsController.ScoredBall();
        }
        else if (collision.gameObject.name == "CueBall(Clone)")
        {
            Destroy(collision.gameObject);
            GameController.Singletone.BallsController.ScoredCueBall();
        }
    }
}
