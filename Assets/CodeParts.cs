using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CodeParts : MonoBehaviour
{
    public static CodeParts Instance = null;



    public runes[] codeParts =
        { runes.none, runes.none, runes.none, runes.none };
    
    
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

    public void AddClue(int i, runes rune)
    {
        codeParts[i] = rune;
    }
}
