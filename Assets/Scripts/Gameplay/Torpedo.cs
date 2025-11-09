using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Torpedo : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 5f;
    public float damage = 1f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        

        Destroy(gameObject, lifetime); // Clean up
    }
    void FixedUpdate()
    {
        rb.AddForce(transform.up * speed, ForceMode.Acceleration);
    }

    void OnTriggerEnter(Collider other)
    {
        // Avoid hitting own boat (optional: use layer mask)
        if (other.CompareTag("Boat"))
        {
            // Damage logic
            Debug.Log($"{other.name} hit for {damage} damage!");
            Destroy(gameObject);
        }
    }
}