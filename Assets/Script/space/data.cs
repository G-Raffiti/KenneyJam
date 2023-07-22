using System;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;


public class data : MonoBehaviour
{
    public static data Instance = null;
    public playerSpaceController player;
    public List<planete> planetes = new List<planete>();

    private Dictionary<string, Vector3> state = new Dictionary<string, Vector3>();
    private List<string> visited = new();

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    
    public void Save(GameObject gameObject)
    {
        if (!state.ContainsKey(gameObject.name))
            state.Add(gameObject.name, new Vector3());
        state[gameObject.name] = gameObject.transform.position;
    }

    public void Load(GameObject obj)
    {
        if (state.Count == 0)
            return;
        if (state.ContainsKey(obj.name))
            obj.transform.position = state[obj.name];
        if (visited.Contains(obj.name))
            obj.GetComponent<Rigidbody2D>().simulated = false;
    }

    public void SaveVisited(string _name)
    {
        if (!visited.Contains(_name))
            visited.Add(_name);
    }
}