using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class RayShoot : MonoBehaviour
{
    private Camera camera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camera = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnGUI()
    {
        int size = 12;
        float posX = camera.pixelWidth / 2 - size / 4;
        float posY = camera.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }
    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector3 point = new Vector3( camera.pixelWidth/2, camera.pixelHeight/2, 0);
            Ray ray = camera.ScreenPointToRay(point);
            RaycastHit raycastHit;
            if (Physics.Raycast(ray, out raycastHit))
            {
                GameObject hitObj = raycastHit.transform.gameObject;
                Enemy target = hitObj.GetComponent<Enemy>();
                if (target != null) target.ReactToHit();
                else StartCoroutine(SphereIndicator(raycastHit.point));
            }
        }
    }

    private IEnumerator SphereIndicator(Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;

        yield return new WaitForSeconds(1);

        Destroy(sphere);
    }    
}
