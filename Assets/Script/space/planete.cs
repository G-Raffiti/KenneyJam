using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class planete : MonoBehaviour
{
    public float rotaionSpeed;
    public float rotaionSpeedSelf;

    public GameObject pivotObject;
    public string planete_scene_name = "";
    public GameObject space;

    private void Start()
    {
        data.Instance.Load(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0,0,1), rotaionSpeedSelf * Time.deltaTime);
        transform.RotateAround(pivotObject.transform.position, new Vector3(0,0,1), rotaionSpeed * Time.deltaTime * 0.1f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("planete triggered " + planete_scene_name + other.CompareTag("Player"));
        if (other.CompareTag("Player"))
            OpenScenePlanete();
    }

    private void OpenScenePlanete()
    {
        if (planete_scene_name == "")
            return;
        SceneManager.LoadScene(planete_scene_name);
    }

    private void OnDestroy()
    {
        data.Instance.Save(gameObject);
        data.Instance.SaveVisited(name);
    }
}
