using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenuUI : MonoBehaviour
{
    [SerializeField] private Canvas MenuCanvas;
    [SerializeField] private Canvas SettingsCanvas;

    public void backtoMenu()
    {
        MenuCanvas.enabled = true;
        SettingsCanvas.enabled = false;
    }

}
