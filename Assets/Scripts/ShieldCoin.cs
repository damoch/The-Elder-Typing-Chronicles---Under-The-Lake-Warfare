using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldCoin : Coin {

    public override void DoYourAction(PlayerController playerController)
    {
        playerController.GetShield();
    }
}
