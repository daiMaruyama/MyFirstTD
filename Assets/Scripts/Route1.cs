using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Route1 : MonoBehaviour
{
    [SerializeField] int pointCount = 5;
    [SerializeField] float spacing = 1f;

    private void Start()
    {
        LineRenderer lr = GetComponent<LineRenderer>();
        lr.positionCount = pointCount;

        for (int i = 0; i < pointCount; i++)
        {
            lr.SetPosition(i, new Vector3(i * spacing, 0, 0));
        }
    }
}