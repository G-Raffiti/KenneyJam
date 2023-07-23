using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFinish : MonoBehaviour
{
    public ComicsPrompter prompt;
    
        // Start is called before the first frame update
    void Start()
    {
        prompt.display("I finally reach my home land...");
    }

    void Quit()
    {
        Application.Quit();
    }
}
