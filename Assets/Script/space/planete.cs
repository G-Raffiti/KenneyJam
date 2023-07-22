using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planete : MonoBehaviour
{
    public float rotaionSpeed;
    public float rotaionSpeedSelf;

    public GameObject pivotObject;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0,0,1), rotaionSpeedSelf * Time.deltaTime);
        transform.RotateAround(pivotObject.transform.position, new Vector3(0,0,1), rotaionSpeed * Time.deltaTime);
    }
}
