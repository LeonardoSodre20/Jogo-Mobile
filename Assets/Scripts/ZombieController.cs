using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    public bool directionZombie;
    public float speedZombie;
    public SpriteRenderer flipZombie;
    
    void Update()
    {
        if(directionZombie)
        {
            transform.Translate(new Vector3(-speedZombie * Time.deltaTime, 0, 0));
            flipZombie.flipX = true;
        }
        else
        {
            transform.Translate(new Vector3(speedZombie * Time.deltaTime, 0, 0));
            flipZombie.flipX = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "direction_zombie")
        {
            directionZombie = !directionZombie;
        }

        if(collision.gameObject.tag == "Bullet")
        {
            Destroy(this.gameObject);
        }
    }
}
