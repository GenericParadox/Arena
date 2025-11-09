using UnityEngine;

public class PlayerBoat : Boat
{
    public bool isPlayer;

    protected override void ReadInput()
    {
        forwardInput = Input.GetAxis("Vertical");
        sideInput = Input.GetAxis("Horizontal");
    }
}
