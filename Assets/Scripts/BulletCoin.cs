
public class BulletCoin : Coin {

    public override void DoYourAction(PlayerController playerController)
    {
        playerController.HasBullet = true;
        Generator.NumberOfObjects--;
    }
}
