using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICodeParts : MonoBehaviour
{
    public List<Image> imgs;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < data.Instance.clueFounded.Count; i++)
        {
            imgs[i].sprite = data.Instance.runes_imgs[data.Instance.clueFounded[i]];
        }
    }
}
