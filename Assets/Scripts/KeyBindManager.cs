using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBindManager : MonoBehaviour
{
    public static KeyBindManager _instance;

    public KeyCode forward { get; set; }
    public KeyCode backward { get; set; }
    public KeyCode left { get; set; }
    public KeyCode right { get; set; }
    
    public KeyCode dash { get; set; }
    public KeyCode dashMinus { get; set; }
    public KeyCode dashPlus { get; set; }


    void Awake()
    {
        if (_instance == null)
        {
            DontDestroyOnLoad(gameObject);
            _instance = this;
        }
        else if (_instance != this)
        {
            DontDestroyOnLoad(gameObject);
        }

        forward = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("forwardKey", "Z"));
        backward = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("backwardKey", "S"));
        left = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("leftKey", "Q"));
        right = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("rightKey", "D"));
        dash = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("dashKey", "A"));
        dashMinus = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("dashMinusKey", "U"));
        dashPlus = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("dashPlusKey", "I"));
    }
}
