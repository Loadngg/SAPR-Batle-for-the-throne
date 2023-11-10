using UnityEngine;

public class NPC : MonoBehaviour
{
    public string[] text;
    private int textIndex = 0;
    private Ui ui;
    [SerializeField] private Ui storytelling;


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer != LayerMask.NameToLayer("Player") || text.Length == 0) return;
        ui = col.gameObject.GetComponentInChildren<Ui>();

        if (!ui.IsVisible()) ui.ShowUi();
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.layer != LayerMask.NameToLayer("Player")  || text.Length == 0) return;

        ui.HideUi();
        textIndex = 0;
        storytelling.HideUi();
    }

    void Update()
    {
        if (!ui) return;

        if (ui.IsVisible() && Input.GetKeyDown(KeyCode.I)) 
        {
            if (!storytelling.IsVisible())
                storytelling.ShowUi();

            if (textIndex == text.Length) textIndex = 0;
            storytelling.SetText(text[textIndex]);
            textIndex++;
        }
    }
}