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
        Vector3 movment;

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
        moveInput = moveInput.normalized;

        if (Keyboard.current.leftShiftKey.isPressed)
        {
            movment = transform.TransformDirection(moveInput) * 2 * speed * Time.fixedDeltaTime;
        }
        else  movment = transform.TransformDirection(moveInput) * speed * Time.fixedDeltaTime;
        
        rb.MovePosition(rb.position + movment);

    }
    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, transform.rotation * Quaternion.Euler(90, 0, 0));
        Rigidbody rbButlet = bullet.GetComponent<Rigidbody>();
        rbButlet.linearVelocity = firePoint.forward * bulletForce; 
        Destroy(bullet, 3f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy")) FindFirstObjectByType<GameManager>().GameOver();   
    }

}
