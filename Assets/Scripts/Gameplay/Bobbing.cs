using UnityEngine;

public class Bobbing : MonoBehaviour
{
    [Header("Bobbing Settings")]
    public float bobAmplitude = 0.2f;    // How high/low it bobs
    public float bobFrequency = 1.5f;    // How fast it bobs
    public float tiltAngle = 10f;        // Max tilt when turning

    private Vector3 startPos;
    private float bobTimer = 0f;

    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
        Bob();
        Tilt();
    }

    void Bob()
    {
        bobTimer += Time.deltaTime * bobFrequency;
        float yOffset = Mathf.Sin(bobTimer) * bobAmplitude;
        transform.localPosition = startPos + new Vector3(0, yOffset, 0);
    }

    void Tilt()
    {
        // Tilt based on horizontal input
        float turn = Input.GetAxis("Horizontal");
        float targetTilt = -turn * tiltAngle;
        Vector3 currentEuler = transform.localEulerAngles;
        // Keep smooth tilt
        float tilt = Mathf.LerpAngle(currentEuler.x, targetTilt, Time.deltaTime * 5f);
        transform.localEulerAngles = new Vector3(tilt, currentEuler.y, currentEuler.z);
    }
}