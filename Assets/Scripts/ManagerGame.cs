using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerGame : MonoBehaviour
{
    public int qtdCoins;
    public Text txtPontuation;
    public Image lifeBar;
    public float damage;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        CoinColletedScene();
      
    }

    public void CoinColletedScene()
    {
        qtdCoins = GameObject.FindGameObjectsWithTag("coin").Length;

        txtPontuation.text = "Coins: " + qtdCoins.ToString();
    }

    public void lifePlayer()
    {
        lifeBar.fillAmount -= damage;
        
    }
}
