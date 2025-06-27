using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LineMaked : MonoBehaviour
{
    public Transform[] points;

    void Start()
    {
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = points.Length;

        for (int i = 0; i < points.Length; i++)
        {
            lineRenderer.SetPosition(i, points[i].position);
        }
    }
}
