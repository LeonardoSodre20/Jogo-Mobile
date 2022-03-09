using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControll : MonoBehaviour
{
    public int qtdPontuation;
    void Start()
    {
        
    }


    void Update()
    {
        if(GameObject.Find("Enemy"))
        {
            int qtdEnemys = GameObject.FindGameObjectsWithTag("enemy").Length;
            
            if(qtdEnemys <= 0)
            {
                qtdPontuation += 1;
                Debug.Log(qtdPontuation);
            }
        }
    }
}
