using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameManager gameManager;

    void OnTriggerEnter2D(Collider2D other)
    {
        
      
        if(other.CompareTag("Player") && GameManager.CurScore >= 15)
        {
            print("You win uwu... or should I say uvu");
             GameUI.instance.SetEndGameScreen(true, GameManager.CurScore);
        }
        else
        {
            print("The Door is locked. You cannot escape!");
        }
    
    }
    
}
