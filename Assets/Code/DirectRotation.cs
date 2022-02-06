using UnityEngine;

public class DirectRotation : ILookAtBehaviour
{
    private readonly Transform _targetTransform;

    public DirectRotation(Transform targetTransform)
    {
        _targetTransform = targetTransform;
    }

    public void DoRotation(Vector2 direction)
    {
        var angle = Mathf.Atan2(direction.y, direction.x) * 180f / Mathf.PI;
        //rotate on Z axis
        _targetTransform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}

public class SmoothRotation : ILookAtBehaviour
{
    public void DoRotation(Vector2 direction)
    {
        throw new System.NotImplementedException();
    }
}