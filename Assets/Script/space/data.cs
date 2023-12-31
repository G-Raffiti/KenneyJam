﻿using System;
using System.Collections.Generic;
using UnityEngine;

public class data : MonoBehaviour
{
    public static data Instance = null;
    public List<runes> runes = new List<runes>();

    public List<runes> all_runes = new List<runes>() { global::runes.activate_planetes , global::runes.radar_switch, global::runes.rotation_speed_minus, global::runes.rotation_speed_plus, global::runes.sound_minus, global::runes.sound_plus, global::runes.speed_minus, global::runes.speed_plus, global::runes.start_rune_code, global::runes.validate_rune_code, global::runes.zoom_minus, global::runes.zoom_plus};
    public Dictionary<runes, Sprite> runes_imgs = new();

    private Dictionary<string, Vector3> state = new Dictionary<string, Vector3>();
    public List<string> visited = new();

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
    }

    public void SaveVisited(string _name)
    {
        if (!visited.Contains(_name))
            visited.Add(_name);
    }

    public void addRunes(List<runes> _runes)
    {
        runes.AddRange(_runes);
    }
    
    
    // save and load button state
    
    public float bg_music_volume = 1;
    public float player_max_speed = -100;
    public bool ping_visible = false;
    public float player_rot_speed = 25;
    public float camera_zoom = 7;

    public void LoadRuneState(BtnHub _btn_hub)
    {
        _btn_hub.bg_music.volume = bg_music_volume;
        _btn_hub.player.maxSpeed = player_max_speed;
        _btn_hub.ping.visible = ping_visible;
        _btn_hub.player.rotationSpeed = player_rot_speed;
        _btn_hub.camera.orthographicSize = camera_zoom;
    }

    public void SaveRuneState(BtnHub _btn_hub)
    {
        bg_music_volume = _btn_hub.bg_music == null ? 0.8f: _btn_hub.bg_music.volume;
        player_max_speed = _btn_hub.player.maxSpeed;
        ping_visible = _btn_hub.ping.visible;
        player_rot_speed = _btn_hub.player.rotationSpeed;
        camera_zoom = _btn_hub.camera == null ? 7: _btn_hub.camera.orthographicSize;
    }
    
    //clues
    private List<string> scene_names = new List<string>();
    public List<runes> code = new List<runes>();
    public List<runes> clueFounded = new List<runes>();
    public void RevealClue(string scene_name)
    {
        if (scene_names.Contains(scene_name)) return;
        scene_names.Add(scene_name);
        clueFounded.Add(code[clueFounded.Count]);
    }
}