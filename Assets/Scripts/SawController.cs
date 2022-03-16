using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawController : MonoBehaviour
{
    public Vector3 rotateSaw;
    public float speedRotation;
    
    void Update()
    {
        RotateSaw();
        
    }

    public void RotateSaw()
    {
        transform.Rotate(rotateSaw * speedRotation);
    }
}
