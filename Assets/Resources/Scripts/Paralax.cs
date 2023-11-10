using UnityEngine;

public class Paralax : MonoBehaviour
{
    private float _lengthX, _startposX,_startposY, _deltaParallaxEffect;
    public GameObject cam;
    public float parallaxEffect;

    void Start()
    {
        _deltaParallaxEffect = 1 - parallaxEffect;
        _startposX = transform.position.x;
        _startposY = transform.position.y;
        _lengthX = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void FixedUpdate()
    {
        float positionX = cam.transform.position.x;
        float positionY = cam.transform.position.y;

        float tempX = positionX * _deltaParallaxEffect;

        float distX = positionX * parallaxEffect;
        float distY = positionY * parallaxEffect;

        transform.position = new Vector3(
            _startposX + distX,
            _startposY + distY,
            transform.position.z
        );

        if (tempX > _startposX + _lengthX)
            _startposX += _lengthX;
        else if (tempX < _startposX - _lengthX)
            _startposX -= _lengthX;
    }
}
