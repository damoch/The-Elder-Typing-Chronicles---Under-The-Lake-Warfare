﻿
public class ShieldCoin : Coin {

    public override void DoYourAction(PlayerController playerController)
    {
        playerController.HasShield = true;
        Generator.NumberOfObjects--;
        playerController.HasShieldText.text = "Masz tarcze";
    }
}
