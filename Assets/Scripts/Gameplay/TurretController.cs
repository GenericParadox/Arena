using UnityEngine;

public class TurretController : MonoBehaviour
{
    [Header("Turret Settings")]
    public Transform trackingTarget;   // What we're aiming at
    public float rotationSpeed = 90f;  // Degrees per second
    public float maxAngle = 80f;       // Max turn angle (not used yet)
    public Transform horizontalPivot;  // Base yaw pivot

    protected virtual void Start()
    {
        AssignTarget();
    }

    protected virtual void Update()
    {
        if (trackingTarget != null)
            TrackTarget();
    }

    protected virtual void AssignTarget()
    {
        // Intentionally blank — overridden in subclasses
    }

    protected void TrackTarget()
    {
        Vector3 targetDir = (trackingTarget.position - transform.position).normalized;

        // --- Horizontal rotation only ---
        if (horizontalPivot != null)
        {
            Vector3 flatDir = new Vector3(targetDir.x, 0, targetDir.z);
            if (flatDir.sqrMagnitude > 0.001f)
            {
                Quaternion desiredYaw = Quaternion.LookRotation(flatDir);
                horizontalPivot.rotation = Quaternion.RotateTowards(
                    horizontalPivot.rotation,
                    desiredYaw,
                    rotationSpeed * Time.deltaTime
                );
            }
        }
    }
}