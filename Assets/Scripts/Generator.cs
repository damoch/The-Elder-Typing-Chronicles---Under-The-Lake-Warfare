using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {

    public Rigidbody2D RenderedObject;
    public int RenderInterval;
    public int SpeedOfRenderObject;
    public float MaxPositionY;
    public float MinPositionY;

    private float _time;
    private Vector2 _renderDirection;

    protected Rigidbody2D _renderedObject;

    void Start ()
    {
        _time = 0;
        _renderDirection = new Vector2(transform.position.x, transform.position.y);
        RenderInterval += UnityEngine.Random.Range(0, 1);
    }
	
	protected void Update ()
    {
        _renderDirection.y = UnityEngine.Random.Range(MinPositionY, MaxPositionY);
        _time += Time.deltaTime;
        if (_time > RenderInterval)
        {
            RenderObject();
            _time = 0;
        }
    }

    protected virtual void RenderObject()
    {
        //if you want to update position of rendered objects
        //_renderDirection = new Vector2(transform.position.x, transform.position.y);

        _renderedObject = Instantiate(RenderedObject, _renderDirection, Quaternion.identity) as Rigidbody2D;
        _renderedObject.AddForce(new Vector2(-SpeedOfRenderObject, 0));
    }
}
