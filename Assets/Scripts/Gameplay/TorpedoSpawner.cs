using UnityEngine;

public class TorpedoSpawner : MonoBehaviour
{
    [Header("Spawner Settings")]
    public GameObject torpedoPrefab;
    public Transform[] spawnPoints;  // Can have multiple
    public float fireCooldown = 2f;

    private float cooldownTimer = 0f;

    void Update()
    {
        cooldownTimer -= Time.deltaTime;

        // Example: Player firing
        if (Input.GetKey(KeyCode.Space) && cooldownTimer <= 0f)
        {
            Fire();
        }
    }

    public void Fire()
    {
        if (torpedoPrefab == null || spawnPoints.Length == 0) return;

        foreach (var point in spawnPoints)
        {
            Instantiate(torpedoPrefab, point.position, point.rotation);
        }

        cooldownTimer = fireCooldown;
    }
}
