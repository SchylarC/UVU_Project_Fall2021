using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public string pickupName;
    public int amount;

    public GameManager gameManager;
   
   void Update()
    {
        transform.Rotate(Vector3.back * 10 * Time.deltaTime);
    }
   void OnTriggerEnter2D(Collider2D other)
   {
       print("you picked up a " + pickupName );
       gameManager.hasKey = true;
       Destroy(gameObject);
   }
}
