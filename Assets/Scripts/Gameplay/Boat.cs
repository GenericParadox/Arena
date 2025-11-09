using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Boat : MonoBehaviour
{
    [Header("Movement Settings")]
    public float maxForwardSpeed = 5f;
    public float acceleration = 1f;
    public float deceleration = 0.5f;

    public float currentTurnRate = 0f;
    [HideInInspector] public float maxTurnRate = 60f;
    [HideInInspector] public float turnAcceleration = 10f;  // how quickly rudder deflects
    [HideInInspector] public float turnDecay = 5f;         // how quickly rudder recenters

    [Header("Vortex Settings")]
    public Transform vortexCenter;  // Center of the vortex
    public float vortexHeightOffset = 0.5f; // How high above the surface the boat should float

    protected Rigidbody rb;
    protected float currentSpeed = 0f;

    protected float forwardInput = 0f;
    protected float sideInput = 0f;

    int layerMask;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rb.freezeRotation = true;
        layerMask = LayerMask.GetMask("Vortex"); // only hit vortex mesh
    }

    protected virtual void Update()
    {
        //Surf(); // Align the boat to the vortex surface
        ReadInput();
        HandleMovement();

    }

    protected virtual void ReadInput()
    {
        forwardInput = 0;
        sideInput = 0;
    }

    protected void HandleMovement()
    {

        // Apply rudder input
        // Smooth out rudder control
        if (Mathf.Abs(sideInput) > 0.1f && Mathf.Abs(forwardInput) > 0.2f)
            currentTurnRate += turnAcceleration * sideInput * Time.deltaTime;
        else
            currentTurnRate = Mathf.MoveTowards(currentTurnRate, 0, turnDecay * Time.deltaTime);

        currentTurnRate = Mathf.Clamp(currentTurnRate, -maxTurnRate, maxTurnRate);

        float normalizedTurn = Mathf.Clamp01(Mathf.Abs(currentTurnRate) / maxTurnRate);
        float speedPenaltyFactor = Mathf.Lerp(1f, 0.5f, Mathf.Pow(normalizedTurn, 1.2f));

        if (Mathf.Abs(forwardInput) > 0.1f)
            currentSpeed += forwardInput * acceleration * Time.deltaTime;
        else
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0, deceleration * Time.deltaTime);


        //currentSpeed = Mathf.Lerp(currentSpeed, currentSpeed * speedPenaltyFactor, Time.deltaTime); // speed penalty applied based on rudder position
        currentSpeed = Mathf.Lerp(currentSpeed, currentSpeed, Time.deltaTime);
        currentSpeed = Mathf.Clamp(currentSpeed, -maxForwardSpeed, maxForwardSpeed);

        transform.Rotate(transform.up, currentTurnRate * Time.deltaTime, 0);
        Vector3 forward = transform.forward * currentSpeed;
        rb.linearVelocity = new Vector3(forward.x, rb.linearVelocity.y, forward.z);
    }

    /// <summary>
    /// Aligns the boat tangentially to the vortex surface and keeps it upright.
    /// </summary>
    protected void Surf()
    {
        if (vortexCenter == null) return;

        RaycastHit hit;
        Vector3 rayOrigin = transform.position + Vector3.up * 5f;
        Vector3 rayDirection = Vector3.down;
        float rayLength = 10f;

        if (Physics.Raycast(rayOrigin, rayDirection, out hit, rayLength, layerMask))
        {
            Debug.DrawLine(rayOrigin, hit.point, Color.green);

            Vector3 surfaceNormal = hit.normal;
            Vector3 toCenter = (hit.point - vortexCenter.position).normalized;
            Vector3 tangent = -Vector3.Cross(surfaceNormal, toCenter).normalized;

            // Align rotation tangentially
            Quaternion targetRotation = Quaternion.LookRotation(tangent, surfaceNormal);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 5f * Time.deltaTime);

            // Adjust only Y to stay "on" the vortex
            Vector3 pos = rb.position;
            pos.y = hit.point.y + vortexHeightOffset;
            rb.position = pos; // NOTE: this preserves horizontal physics
        }
    }
}
