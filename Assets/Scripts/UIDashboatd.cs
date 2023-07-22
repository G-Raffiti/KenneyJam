using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDashboatd : MonoBehaviour
{
    [SerializeField] private Button btnToggleKeyBind;
    [SerializeField] private GameObject uiKeyBind; 

    private bool isKeyBindDisplay = false;


    public void OnKeyBindToggle()
    {
        isKeyBindDisplay = !isKeyBindDisplay;
        uiKeyBind.SetActive(isKeyBindDisplay);
    }
}
