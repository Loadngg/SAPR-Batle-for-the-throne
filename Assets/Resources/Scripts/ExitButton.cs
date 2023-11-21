using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButton : MonoBehaviour
{
    public void ExitToMainMenu()
    {
        Debug.Log("Сохранение");
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}