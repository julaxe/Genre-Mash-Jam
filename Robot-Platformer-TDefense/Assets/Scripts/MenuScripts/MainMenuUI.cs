using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Canvas MenuCanvas;
    [SerializeField] private Canvas SettingsCanvas;
    public void LoadGame()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void OpenSettings()
    {
        MenuCanvas.enabled = false;
        SettingsCanvas.enabled = true;
    }

    public void QuitApplication()
    {
        Application.Quit();
    }

}
