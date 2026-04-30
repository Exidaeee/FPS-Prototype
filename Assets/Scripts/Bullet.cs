using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10.0f;
    public int damage = 1;

    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (player!= null)
        {
            player.Hurt(damage);

        }
        Destroy(gameObject);
    }
}
