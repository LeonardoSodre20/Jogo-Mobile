using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBarrel : MonoBehaviour
{
    public bool directionBarrel;
    public float speed;
    void Update()
    {
        if(directionBarrel)
        {
            transform.Translate(-speed * Time.deltaTime, 0,0);
        }
        else
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "direction_barrel")
        {
            directionBarrel = !directionBarrel;
        }
    }
}
