using System.Collections;
using TarodevController;
using UnityEngine;

public class PlayerCustomController : MonoBehaviour
{
    Rigidbody2D rb;
    PlayerController controller;
    public GameObject magicPrefab;
    public GameObject weaponPrefab;
    public GameObject pauseUi;
    public Hearts hearts;
    [SerializeField] private float magicLifeTime = .3f;
    [SerializeField] private float weaponLifeTime = .3f;
    [SerializeField] private float magicDistance = 25f;
    public float dashDistance = 10f;
    bool rightView = true;
    bool inPause = false;
    public AudioSource audioSource;
    public AudioClip magicAudio;
    public float volume = 0.1f;
    GameObject weapon;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        controller = GetComponent<PlayerController>();
    }

    void Update()
    {
        float movement = Input.GetAxisRaw("Horizontal");
        if (movement != 0) rightView = movement > 0;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (rightView) StartCoroutine(Dash(1f));
            else StartCoroutine(Dash(-1f));
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            inPause = !inPause;
            pauseUi.SetActive(inPause);
            if (inPause)
                Time.timeScale = 0;
            else
                Time.timeScale = 1;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (hearts.GetHeartsCount() == 1) return;
            GameObject magic = Instantiate(magicPrefab, transform);
            audioSource.PlayOneShot(magicAudio, volume);
            hearts.GetDamage();
            if (rightView) StartCoroutine(Magic(magic, 1f));
            else StartCoroutine(Magic(magic, -1f));
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            if (weapon) return;
            weapon = Instantiate(weaponPrefab, transform);
            float size = weapon.GetComponent<CapsuleCollider2D>().size.x;

            if (rightView)
                weapon.transform.localPosition = new Vector2(size, 0);
            else
                weapon.transform.localPosition = new Vector2(-size, 0);
            StartCoroutine(Weapon(weapon));
        }
    }

    IEnumerator Magic(GameObject magic, float direction)
    {
        magic.GetComponent<Rigidbody2D>().AddForce(new Vector2(magicDistance * direction, 0f), ForceMode2D.Impulse);
        yield return new WaitForSeconds(magicLifeTime);
        Destroy(magic);
    }

    IEnumerator Weapon(GameObject weapon)
    {
        yield return new WaitForSeconds(weaponLifeTime);
        Destroy(weapon);
    }

    IEnumerator Dash(float direction)
    {
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
