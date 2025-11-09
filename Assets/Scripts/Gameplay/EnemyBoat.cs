using UnityEngine;

public class EnemyBoat : Boat
{
    private float changeTimer;
    public float decisionInterval = 2f;

    protected override void ReadInput()
    {
        changeTimer -= Time.deltaTime;
        if (changeTimer <= 0f)
        {
            forwardInput = Random.Range(-1f, 1f);
            sideInput = Random.Range(-1f, 1f);
            changeTimer = decisionInterval;
        }
    }
}
