using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int hp = 10;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Player")) col.gameObject.GetComponent<Hearts>().GetDamage();
        if (col.gameObject.layer == LayerMask.NameToLayer("Magic")) hp -= 5;
        if (col.gameObject.layer == LayerMask.NameToLayer("Weapon")) hp -= 2;

        if (hp <= 0) Destroy(gameObject);
    }
}