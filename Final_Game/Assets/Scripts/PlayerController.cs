using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public float turnSpeed = 50.0f;
    public int curHp;
    public int maxHp;
    public int CurScore = 0;
    public int MaxScore;
    public float hInput;
    public float vInput;
    private int damage;

    public float xRange = 14.61f;
    public float yRange = 7.06f;
    public Vector3 offset = new Vector3(0,1,0);

    private Vector3 temp = new Vector3();
    public GameObject hitParticle;


    
    // Update is called once per frame
    void Update()
    {
        
        
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        transform.Rotate(Vector3.back, turnSpeed * hInput * Time.deltaTime);
        transform.Translate(Vector3.up * speed * vInput * Time.deltaTime);

        // Create walls on the x and -x sides 
        if(transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z); 
        }

        if(transform.position.x > xRange)
        {
            transform.position = new Vector3 (xRange, transform.position.y, transform.position.z);
        }

        // Create walls on the y and -y sides 
        if(transform.position.y < -yRange)
        {
            transform.position = new Vector3(transform.position.x, -yRange, transform.position.z);
        }

        if(transform.position.y > yRange)
        {
            transform.position = new Vector3(transform.position.x, yRange, transform.position.z);
        }

        //top right wall
        if(transform.position.y > 2.45 - .30 && transform.position.y < 4.66 + .30 && transform.position.x < 11 + .30 && transform.position.x >10 - .30)
            transform.position = new Vector3(temp.x, temp.y, transform.position.z); 
        else //top left wall
         if(transform.position.y > 2.45 - .30 && transform.position.y < 4.66 + .30 && transform.position.x > -11 - .30 && transform.position.x < -10 + .30)
            transform.position = new Vector3(temp.x, temp.y, transform.position.z); 
        else //bottom right wall
        if(transform.position.y < -2.45 + .15 && transform.position.x < 11 + .35 && transform.position.x >10 - .30)
            transform.position = new Vector3(temp.x, temp.y, transform.position.z);
        else//bottom left wall
        if(transform.position.y < -2.45 + .15 && transform.position.x > -11 - .35 && transform.position.x < -10 + .30)
            transform.position = new Vector3(temp.x, temp.y, transform.position.z);
        else //center wall
        if(transform.position.y > -.6 && transform.position.y < .97 && transform.position.x > -9.39 && transform.position.x < 9.38)
            transform.position = new Vector3(temp.x, temp.y, transform.position.z);
        else //big center wall
        if(transform.position.y > 2.21 && transform.position.y < 5.02 && transform.position.x > -3.31 && transform.position.x < 3.35)
            transform.position = new Vector3(temp.x, temp.y, transform.position.z);
        else //bottom middle right wall
        if(transform.position.y < -2.3 && transform.position.x > 2.63 && transform.position.x < 4.32)
            transform.position = new Vector3(temp.x, temp.y, transform.position.z);
        else //bottom middle left wall
        if(transform.position.y < -2.3 && transform.position.x < -2.63 && transform.position.x > -4.32)
            transform.position = new Vector3(temp.x, temp.y, transform.position.z);
        


        
        // Pause the game when the pause menu is pressed
        if(GameManager.instance.gamePaused == true)
            return;
       
       temp = transform.position;
    }
    
    public void GiveScore(int amountToGive)
    {
        //add one if we run over a coin
        CurScore+=1;
        GameUI.instance.UpdateScoreText(CurScore);
    }

    // Run when players health is zero
    void Die()
    {
        GameManager.instance.LoseGame();
    }



    // Applies damage to the player
    public void TakeDamage(int damage)
    {
       curHp -= damage;
        if(curHp <= 0)
            Die();
        
    }
     void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
            other.GetComponent<PlayerController>().TakeDamage(damage);
       GameObject obj = Instantiate(hitParticle, transform.position, Quaternion.identity);
            
    }
}
