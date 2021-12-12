using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public PickupType type;
    public int value;
    public enum PickupType
    {
        Score
    }

    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();

            switch(type)
            {
                case PickupType.Score :
                GameManager.CurScore +=1;
                
                GameUI.instance.UpdateScoreText(GameManager.CurScore);
                break;
            }
            // Destroy Pick up 
            Destroy(gameObject);
        }

    }


   
}

