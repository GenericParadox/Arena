using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Boat : MonoBehaviour
{
    [Header("Movement Settings")]
    public float maxForwardSpeed = 5f;
    public float acceleration = 1f;      // How fast speed increases
    public float deceleration = 0.5f;      // How fast it slows down when no input
    public float turnSpeed = 90f;        // Degrees per second

    private Rigidbody rb;
    private float currentSpeed = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // We'll handle rotation manually
    }

    void Update()
    {
        HandleMovement();
    }
    void UserInput()
    {

    }
    void HandleMovement(float forwardInput, float sideInput)
    {
        // --- Throttle input ---
        //float throttle = forwardInput; // W/S or Up/Down arrows
        float throttle = Input.GetAxis("Vertical"); // W/S or Up/Down arrows

        // Accelerate or decelerate
        if (Mathf.Abs(throttle) > 0.01f)
        {
            currentSpeed += throttle * acceleration * Time.deltaTime;
        }
        else
        {
            // Slowly reduce speed when no input
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0, deceleration * Time.deltaTime);
        }

        // Clamp speed
        currentSpeed = Mathf.Clamp(currentSpeed, -maxForwardSpeed, maxForwardSpeed);

        // --- Turn input ---
        // --- Turn only while moving ---
        if (currentSpeed > 0.2f)
        {
            //float turn = sideInput; // A/D or Left/Right arrows
            float turn = Input.GetAxis("Horizontal"); // A/D or Left/Right arrows
            if (Mathf.Abs(turn) > 0.01f)
            {
                transform.Rotate(0, turn * turnSpeed * currentSpeed / maxForwardSpeed * Time.deltaTime, 0);
            }
        }

        // --- Apply movement ---
        Vector3 forward = transform.forward * currentSpeed;
        rb.linearVelocity = new Vector3(forward.x, rb.linearVelocity.y, forward.z); // preserve vertical
    }

}