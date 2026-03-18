using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    public Transform player; 
    public float sensitivity = 100f;

    float xRotation = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Mouse.current.delta.x.ReadValue() * sensitivity * Time.deltaTime;
        float mouseY = Mouse.current.delta.y.ReadValue() * sensitivity * Time.deltaTime;
  
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
      
        player.Rotate(Vector3.up * mouseX);

    }
}
