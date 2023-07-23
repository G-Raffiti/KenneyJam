using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICodeParts : MonoBehaviour
{
    public List<Sprite> imgs;
    public Sprite defaultImg;
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (runes rune in CodeParts.Instance.codeParts)
        {
            Sprite img = defaultImg;
            data.Instance.runes_imgs.TryGetValue(rune, out img);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
