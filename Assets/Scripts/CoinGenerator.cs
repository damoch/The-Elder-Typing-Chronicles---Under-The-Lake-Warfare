using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : Generator {

    public Rigidbody2D ShieldCoin;
    public Rigidbody2D BulletCoin;

    //private Rigidbody2D[] _coins = new Rigidbody2D[]
    //{
    //    ShieldCoin,
    //    BulletCoin
    //};

    private void Update () {
        int rand = Random.RandomRange(0, 1);
        RenderedObject = (rand == 1) ? ShieldCoin : BulletCoin;
        base.Update();
	}
}
