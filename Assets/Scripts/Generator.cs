using UnityEngine;

public class Generator : MonoBehaviour {

    public Rigidbody2D RenderedObject;
    public int SpawnInterval;
    public int SpeedOfRenderObject;
    public float MaxPositionY;
    public float MinPositionY;
    public int MinSpawnInterval;
    public int MaxSpawnInterval;
    public float MaxNumberOfObjects;

    private float _time;
    private Vector2 _renderDirection;

    protected Rigidbody2D _renderedObject;

    public static int NumberOfObjects;

    void Start ()
    {
        _time = 0;
        _renderDirection = new Vector2(transform.position.x, transform.position.y);
        SpawnInterval = Random.Range(MinSpawnInterval, MaxSpawnInterval);
    }
	
	protected void Update ()
    {
        _renderDirection.y = Random.Range(MinPositionY, MaxPositionY);
        _time += Time.deltaTime;
        if (_time > SpawnInterval)
        {
            if(NumberOfObjects < MaxNumberOfObjects)
                RenderObject();
            _time = 0;
            SpawnInterval = Random.Range(MinSpawnInterval, MaxSpawnInterval);
        }
    }

    protected virtual void RenderObject()
    {
        NumberOfObjects++;
        _renderedObject = Instantiate(RenderedObject, _renderDirection, Quaternion.identity) as Rigidbody2D;
        _renderedObject.AddForce(new Vector2(-SpeedOfRenderObject, 0));
    }
}
