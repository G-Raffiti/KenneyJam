using System;
using UnityEngine;

public class ping : MonoBehaviour
{
    public planete planete;

    public Transform player;

    public SpriteRenderer sprite;
    private bool fade = true;

    public bool visible = false;
    public Camera camera_ref;
    
    // Update is called once per frame
    void Update()
    {
        if (!visible) return;
        
        float rotation = Mathf.Deg2Rad * player.rotation.eulerAngles.z;
        Vector2 direction = planete.transform.position - player.position;

        direction = Rotate(direction, -rotation);
        float factor = 1;
        if (Math.Abs(direction.y) > Math.Abs(direction.x))
            factor = 6 / Math.Abs(direction.y);
        else
            factor = 10 / Math.Abs(direction.x);
        transform.localPosition = new Vector3((direction * factor).x, (direction * factor).y, 10) ;

        Color color = sprite.color;
        
        if (fade)
        {
            if (color.a < 0.1)
                fade = !fade;
            color = new Color(color.r, color.g, color.b, color.a - Time.deltaTime);
        }
        else
        {
            if (color.a > 0.8)
                fade = !fade;
            color = new Color(color.r, color.g, color.b, color.a + Time.deltaTime);
        }

        sprite.color = color;

    }
    
    public static Vector2 Rotate(Vector2 v, float delta)
    {
        return new Vector2(
            v.x * Mathf.Cos(delta) - v.y * Mathf.Sin(delta),
            v.x * Mathf.Sin(delta) + v.y * Mathf.Cos(delta)
        );
    }
}
