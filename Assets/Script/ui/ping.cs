using System;
using UnityEngine;

public class ping : MonoBehaviour
{
    public planete planete;

    public Transform player;

    public SpriteRenderer sprite;
    private bool fade = true;
    
    // Update is called once per frame
    void Update()
    {
        float rotation = Mathf.Deg2Rad * player.rotation.eulerAngles.z;
        Vector2 direction = planete.transform.position - player.position;

        direction = Rotate(direction, -rotation);
        float factor = 1;
        if (Math.Abs(direction.y) > Math.Abs(direction.x))
            factor = 7 / Math.Abs(direction.y);
        else
            factor = 12 / Math.Abs(direction.x);
        transform.localPosition = direction * factor;

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
