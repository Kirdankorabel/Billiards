using UnityEngine;

public class TouchTracker : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private CueBall _cueBall;

    public CueBall CueBall
    {
        set => _cueBall = value;
    }
        
    private Vector3 _position;
    public Vector3 Position => _position;

    private void Update()
        => Wath();

    private void OnMouseUp()
    {
        var groundPlane = new Plane(Vector3.up, Vector3.zero);
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

        if (groundPlane.Raycast(ray, out float position))
        {
            Vector3 pos = ray.GetPoint(position);
            _cueBall.Impact(pos);
        }
    }
    private void Wath()
    {
        RaycastHit hit;
        //Touch touch = Input.GetTouch(0);
        //var ray = Camera.main.ScreenPointToRay(touch.position);
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            _position = hit.point;
    }
}
