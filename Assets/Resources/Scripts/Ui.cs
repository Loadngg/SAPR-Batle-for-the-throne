using TMPro;
using UnityEngine;
using System.Collections;

public class Ui : MonoBehaviour
{
    private CanvasGroup ui;
    private bool fadeIn;
    private bool fadeOut;
    [SerializeField] private float fadeTimeScale = 5f;
    [SerializeField] private TextMeshProUGUI text;

    void Start()
    {
        ui = GetComponent<CanvasGroup>();
    }
    
    void Update()
    {
        if (fadeIn && !fadeOut)
            if (ui.alpha < 1)
            {
                ui.alpha += fadeTimeScale * Time.unscaledDeltaTime;
                if (ui.alpha >= 1) fadeIn = false;
            }

        if (!fadeIn && fadeOut)
            if (ui.alpha >= 0)
            {
                ui.alpha -= fadeTimeScale * Time.unscaledDeltaTime;
                if (ui.alpha == 0) fadeOut = false;
            }
    }

    public void ShowUi()
    {
        fadeIn = true;
        fadeOut = false;
    }

    public void HideUi()
    {
        fadeIn = false;
        fadeOut = true;
    }

    public void SetText(string text, bool smoothText = true)
    {
        if (smoothText) StartCoroutine(FadeInText(fadeTimeScale));
        this.text.text = text;
    }

    public bool IsVisible()
    {
        return ui.alpha == 1;
    }

    IEnumerator FadeInText(float timeSpeed)
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
        while (text.color.a < 1.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.unscaledDeltaTime * timeSpeed));
            yield return null;
        }
    }
}