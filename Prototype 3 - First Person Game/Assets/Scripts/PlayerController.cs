using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

[Header("Stats")]
    public float moveSpeed;             // Movement speed in units per second
    public float jumpForce;             // Force applied upwards

    public int curHp;
    public int maxHp;

    [Header("Mouse Look")]
    public float lookSensitivity;       // Mouse look sensitivity
    public float maxLookX;              // Lowest down we can look
    public float minLookX;              // Highest up we can look 
    private float rotX;                 // Current x rotation of the camera 

    private Camera camera;
    private Rigidbody rb;
    private Weapon weapon;

    void Awake()
    {
        weapon = GetComponent<Weapon>();
    }
    // Start is called before the first frame update
    void Start()
    {
        // get components
        camera = Camera.main;
        rb = GetComponent<Rigidbody>();
    }
    // Applies damage to the player
      public void TakeDamage(int damage)
    {
        curHp -= damage;

        if(curHp<= 0)
            Die();
    }
    // If player's health is zero or below the run Die()
    void Die()
    {
        
    }    

       void Move()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;

        // rb.velocity = new Vector3(x, rb.velocity.y, z); - Old Code  
        // Move direction relative to camera 
        Vector3 dir = transform.right * x + transform.forward * z;
        
        dir.y = rb.velocity.y;
        rb.velocity = dir;
    }

     void CamLook()
    {
        float y = Input.GetAxis("Mouse X") * lookSensitivity;
        rotX += Input.GetAxis("Mouse Y") * lookSensitivity;

        rotX = Mathf.Clamp(rotX, minLookX, maxLookX);
        camera.transform.localRotation = Quaternion.Euler(-rotX, 0, 0);
        transform.eulerAngles += Vector3.up * y;    
    }

    void Jump()
    {
        Ray ray = new Ray(transform.position, Vector3.down);

        if(Physics.Raycast(ray, 1.1f))
        {
            // Add force to jump
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);  
        }           
   
    }

    public void GiveHealth( int amountToGive)
    {
        curHp =  Mathf.Clamp(curHp + amountToGive, 0, maxHp);
    }

    public void GiveAmmo(int amountToGive)
    {
        weapon.curAmmo = Mathf.Clamp(weapon.curAmmo + amountToGive, 0, weapon.maxAmmo);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CamLook();
        // Fire Button
        if(Input.GetButton("Fire1"))
        {
            if(weapon.CanShoot())
                weapon.Shoot();
        }
        // Jump Button
         if(Input.GetButtonDown("Jump"))
            Jump();
    }
}
