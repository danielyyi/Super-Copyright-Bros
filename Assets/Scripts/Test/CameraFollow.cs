using Unity;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
public class CameraFollow : MonoBehaviour
{
    public List<Transform> targets;
    public Vector3 offset;
    public float speed = 1f;
    public AnimationCurve distanceCurve;
    private Vector3 targetPosition;
    void Awake()
    {
        targetPosition = new Vector3(
          transform.position.x,
          transform.position.y,
          transform.position.z
         );
    }
    void Update()
    {
        if (targets.Count == 0)
        {
            return;
        }
        targetPosition.x = targetPosition.y = targetPosition.z = 0f;
        foreach (var target in targets)
        {
            if (target == null)
            {
                continue;
            }
            targetPosition.x += target.position.x;
            targetPosition.y += target.position.y;
        }
        var positionsX = targets.Select(t => t.position.x).ToArray();
        var positionsY = targets.Select(t => t.position.y).ToArray();
        var minX = Mathf.Min(positionsX);
        var maxX = Mathf.Max(positionsX);
        var minY = Mathf.Min(positionsY);
        var maxY = Mathf.Max(positionsY);
        var sizeX = Mathf.Abs(maxX - minX);
        var sizeY = Mathf.Abs(maxY - minY);
        var diagonal = Mathf.Sqrt((sizeX * sizeX) + (sizeY * sizeY));
        targetPosition.x = targetPosition.x / targets.Count;
        targetPosition.y = targetPosition.y / targets.Count;
        targetPosition.z = distanceCurve.Evaluate(diagonal);
        Camera.main.transform.position = Vector3.Lerp(
          Camera.main.transform.position,
          targetPosition + offset,
          Time.deltaTime * speed
        );
    }
}