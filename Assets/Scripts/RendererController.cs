using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RendererController : MonoBehaviour {

    public Rigidbody2D RenderedObject;
    public int RenderInterval;
    public int SpeedOfRenderObject;

    private float _time;
    private Vector2 _renderDirection;

    void Start () {
        _time = 0;
        _renderDirection = new Vector2(transform.position.x, transform.position.y);
        RenderInterval += UnityEngine.Random.Range(0, 1);
    }

    void Update () {

        _time += Time.deltaTime;
        if (_time > RenderInterval)
        {
            RenderObject();
            _time = 0;
        }
	}

    private void RenderObject()
    {
        //if you want to update position of rendered objects
        //_renderDirection = new Vector2(transform.position.x, transform.position.y);

        Rigidbody2D _badGuyInstance = Instantiate(RenderedObject, _renderDirection, Quaternion.identity) as Rigidbody2D;
        _badGuyInstance.AddForce(new Vector2(-SpeedOfRenderObject, 0));
    }
}
