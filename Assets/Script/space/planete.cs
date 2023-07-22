using UnityEngine;
using UnityEngine.SceneManagement;

public class planete : MonoBehaviour
{
    public float rotaionSpeed;
    public float rotaionSpeedSelf;

    public GameObject pivotObject;
    public string planete_scene_name = "";

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0,0,1), rotaionSpeedSelf * Time.deltaTime);
        transform.RotateAround(pivotObject.transform.position, new Vector3(0,0,1), rotaionSpeed * Time.deltaTime * 0.1f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            OpenScenePlanete();
    }

    private void OpenScenePlanete()
    {
        if (planete_scene_name == "")
            return;
        SceneManager.LoadScene(planete_scene_name, LoadSceneMode.Additive);
    }
}
