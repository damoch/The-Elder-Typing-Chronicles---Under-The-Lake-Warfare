using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {

    private Vector2 startPosition;

    void Start () {
        startPosition = new Vector2(46, 0);
        Debug.Log(transform.position);
    }

    void Update () {
        transform.Translate(new Vector2(-1, 0));
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("DestructiveWall"))
        {
            transform.position = startPosition;
        }
    }

    private void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
