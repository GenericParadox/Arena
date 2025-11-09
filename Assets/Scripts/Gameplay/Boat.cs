using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Boat : MonoBehaviour
{
    [Header("Movement Settings")]
    public float maxForwardSpeed = 5f;
    public float acceleration = 1f;
    public float deceleration = 0.5f;
    public float turnSpeed = 0.000005f;
    public float turnRate = 0f;
    public float currentTurnRate = 0f;
    public float maxTurnRate = 50f;

    protected Rigidbody rb;
    protected float currentSpeed = 0f;

    protected float forwardInput = 0f;
    protected float sideInput = 0f;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    protected virtual void Update()
    {
        ReadInput();
        HandleMovement();
    }

    protected virtual void ReadInput()
    {
        // placeholder — subclasses override this
        forwardInput = 0;
        sideInput = 0;
    }

    protected void HandleMovement()
    {
        if (Mathf.Abs(forwardInput) > 0.01f)
            currentSpeed += forwardInput * acceleration * Time.deltaTime;
        else
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0, deceleration * Time.deltaTime);

        currentSpeed = Mathf.Clamp(currentSpeed, -maxForwardSpeed, maxForwardSpeed);

        if (Mathf.Abs(sideInput) > 0.5f && Mathf.Abs(currentSpeed) > 0.2f)
        {
            currentTurnRate += turnSpeed * sideInput * Time.deltaTime;
        }
        else
        {
            //currentTurnRate = Mathf.MoveTowards(currentTurnRate, 0, turnRate * Time.deltaTime);
        }
        currentTurnRate = Mathf.Clamp(currentTurnRate, -maxTurnRate, maxTurnRate);
        print("currentTurnRate: " + currentTurnRate);
        print("sideInput: " + sideInput);

        transform.Rotate(0, currentTurnRate * currentSpeed / maxForwardSpeed * Time.deltaTime, 0);

        Vector3 forward = transform.forward * currentSpeed;
        rb.linearVelocity = new Vector3(forward.x, rb.linearVelocity.y, forward.z);
    }
}
