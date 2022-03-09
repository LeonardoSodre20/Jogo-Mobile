using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemys : MonoBehaviour
{
    public GameObject enemy;
    public Vector3 rotationEnemy;
    public bool direction;
    public float speed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Destroy(enemy.gameObject);
        }

        if(collision.gameObject.tag == "directionMove")
        {
            direction = !direction;
        }

        
    }
    private void Update()
    {
        moveEnemy();
    }

    public void moveEnemy()
    {
 
        //transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        transform.Rotate(rotationEnemy);

        if(direction)
        {
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        }
        else
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
       
    }

}
