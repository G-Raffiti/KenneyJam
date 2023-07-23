using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CodeParts : MonoBehaviour
{
    public static CodeParts Instance = null;



    
    
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void AddClue(runes rune)
    {
        
    }
}
