using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    private Rigidbody2D _rb;
    private Vector2 moveVector;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        moveVector.y = Input.GetAxis("Vertical");
        _rb.MovePosition(_rb.position + moveVector * speed * Time.deltaTime);
    }
}
