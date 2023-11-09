using System.Collections;
using TarodevController;
using UnityEngine;

public class DashController : MonoBehaviour
{
    Rigidbody2D rb;
    PlayerController controller;

    public float dashDistance = 10f;
    bool rightView = true;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        controller = GetComponent<PlayerController>();
    }

    void Update() {
        float movement = Input.GetAxisRaw("Horizontal");
        if (movement != 0) rightView = movement > 0;
        
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (rightView) StartCoroutine(Dash(1f));
            else StartCoroutine(Dash(-1f));
        }
    }

    IEnumerator Dash (float direction) {
        controller.enabled = false;
        float gravity = rb.gravityScale;
        rb.gravityScale = 0;
        
        rb.velocity = new Vector2(0f, 0f);
        rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        rb.AddForce(new Vector2(dashDistance * direction, 0f), ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.3f);
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        
        rb.gravityScale = gravity;
        controller.enabled = true;
    } 
}
