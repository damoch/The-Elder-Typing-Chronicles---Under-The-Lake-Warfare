using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {
    
    private void DestroyGameObject()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            DestroyGameObject();
            DoYourAction(collision.gameObject.GetComponent<PlayerController>());
        }
    }

    public virtual void DoYourAction(PlayerController playerController)
    {
        Debug.Log("You should override this method or don't use this class D :");
        throw new NotImplementedException();
    }
}
