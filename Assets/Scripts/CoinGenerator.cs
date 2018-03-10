using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : Generator {
    public List<Rigidbody2D> PowerUpList;
    public int SpawnedObjectIndex;
    public static int NumberOfCoins;
    protected override void Update () {
        if (SpawnedObjectIndex > PowerUpList.Count - 1) SpawnedObjectIndex = 0;
        RenderedObject = PowerUpList[SpawnedObjectIndex++];
        base.Update();
	}

    protected override bool CanCreateObject()
    {
        return NumberOfCoins < MaxNumberOfObjects;
    }
}
