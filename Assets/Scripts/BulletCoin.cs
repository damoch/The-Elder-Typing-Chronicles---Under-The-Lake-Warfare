using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCoin : Coin {

    public override void DoYourAction(PlayerController playerController)
    {
        playerController.GetBullet();
    }
}
