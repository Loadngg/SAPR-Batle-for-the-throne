using UnityEngine;

public class Hearts : MonoBehaviour
{
    public GameObject[] hearts;
    private int _countFilled;

    void Awake()
    {
        _countFilled = hearts.Length;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) GetDamage();
        if (Input.GetKeyDown(KeyCode.Q)) Heal();
    }

    public void GetDamage(int damage = 1)
    {
        hearts[_countFilled - 1].SetActive(false);
        if (_countFilled == 0) return;
        if (_countFilled > 0) _countFilled -= damage;
    }

    public int GetHeartsCount()
    {
        return _countFilled;
    }

    public void Heal()
    {
        hearts[_countFilled].SetActive(true);
        if (_countFilled < hearts.Length - 1) _countFilled++;
    }
}