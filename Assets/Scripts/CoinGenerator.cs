using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : Generator {

    public List<Rigidbody2D> PowerUpList;
    public static int NumberOfCoins;
    new private void Update () {
        RenderedObject = PowerUpList[Random.Range(0, PowerUpList.Count -1)];
        base.Update();
	}
}
