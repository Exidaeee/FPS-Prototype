using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float speed = 1f;
    public float jumpForce = 3f;

    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletForce = 20f;

    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null) Debug.LogWarning("PlayerController needs a Rigidbody.");
        rb.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX;
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        }

        if(Mouse.current.leftButton.wasPressedThisFrame)
        {
            Shoot();
        }
        
    }

    private void FixedUpdate()
    {
        Vector3 moveInput = Vector3.zero;

        if (Keyboard.current.wKey.isPressed)
        {
            moveInput.z = 1f;
        } 
        if(Keyboard.current.sKey.isPressed)  
        {
            moveInput.z = -1f;
        }
        if (Keyboard.current.aKey.isPressed)
        { 
            moveInput.x = -1f;
        }
        if (Keyboard.current.dKey.isPressed)
        {
            moveInput.x = 1f;
        }

        Vector3 movment = moveInput * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movment);

    }
    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rbButlet = bullet.GetComponent<Rigidbody>();
        rbButlet.linearVelocity = firePoint.forward * bulletForce; 
        Destroy(bullet, 3f);
    }    
}
