using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
public float speed = 10.5f;
public float turnSpeed;


    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
    transform.Translate(Vector3.forward * speed * Time.deltaTime);  
    }
}