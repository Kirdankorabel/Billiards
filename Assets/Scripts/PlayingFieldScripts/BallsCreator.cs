using System.Collections.Generic;
using UnityEngine;

public class BallsCreator : MonoBehaviour
{
    [SerializeField] private GameObject _ballPrefab;
    private List<GameObject> _objects;

    private void Awake()
        => _objects = new List<GameObject>();

    public void InstantiateBalls(Vector3 startCoordinates)
    {
        ClearObjects();
        
        Vector3 position;
        for (var i = 0; i < 5; i++)
        {
            for (var j = -i; j < i + 1; j++)
            {
                if (i % 2 == 0 && j % 2 == 0)
                {
                    position = startCoordinates + new Vector3(i * 0.87f, 0, j * 0.5f);
                    var ball = Instantiate(_ballPrefab, position, Quaternion.identity, this.gameObject.transform);
                    _objects.Add(ball);
                }
                else if (i % 2 == 1 && j % 2 != 0)
                {
                    position = startCoordinates + new Vector3(i * 0.87f, 0, j * 0.5f);
                    var ball = Instantiate(_ballPrefab, position, Quaternion.identity, this.gameObject.transform);
                    _objects.Add(ball);
                }
            }
        }
    }

    private void ClearObjects()
    {
        foreach (var go in _objects)
            if (go.gameObject != null)
                Destroy(go.gameObject);
        _objects = new List<GameObject>();
    }
}
