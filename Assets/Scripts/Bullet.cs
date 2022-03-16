using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private bool dir;
    public Player player;
    SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        dir = !player.sprite.flipX;
        sprite = GetComponent<SpriteRenderer>();
        sprite.flipX = !dir;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(dir)
        {
            transform.position = new Vector2(transform.position.x + .25f, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - .25f, transform.position.y);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject, 3f);
    }
}
