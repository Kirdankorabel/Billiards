using UnityEngine;

public class CueBallTracker : MonoBehaviour
{
    [SerializeField] private LineRenderer _line;
    [SerializeField] private GameObject _cueBallDisplay;
    [SerializeField] private CueBall _cueBall;
    private Ball _ball;

    private void LateUpdate()
    {
        if (!_cueBall.isMove)
        {
            _line.SetPosition(0, transform.position);
            _cueBallDisplay.SetActive(true);
            _line.enabled = true;
            ShowImpactDirection(GameController.Singletone.TouchTracker.Position);
        }
        else
        {
            _cueBallDisplay.SetActive(false);
            _line.enabled = false;
        }
    }

    public void ShowReboundDirection(Vector3 direction)
    {
        _line.positionCount = 3;
        _line.SetPosition(2, _cueBallDisplay.transform.position + direction * 2);
    }

    private void ShowImpactDirection(Vector3 mousPos)
    {
        var direction = (transform.position - mousPos).normalized;
        direction.y = 0;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, direction, out hit))
        {
            _line.positionCount = 2;
            _line.SetPosition(1, hit.point);

            _cueBallDisplay.transform.position = new Vector3(hit.point.x, 0, hit.point.z);
            _cueBallDisplay.SetActive(true);

            CalculateReflection(hit.collider.gameObject, direction.normalized);
        }
    }

    private void CalculateReflection(GameObject gameObject, Vector3 direction)
    {
        if (gameObject.name == "Ball")
        {
            var normal = (gameObject.transform.position - _cueBallDisplay.transform.position).normalized;

            _cueBall.Direction = Vector3.Reflect(direction, normal).normalized;
            _ball = gameObject.GetComponent<Ball>();
            _ball.ShowImpactDirection(normal);
            ShowReboundDirection(_cueBall.Direction);
        }
    }
}
