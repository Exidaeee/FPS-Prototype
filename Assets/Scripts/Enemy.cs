using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform target;
    private GameManager gameManager;
    [SerializeField] GameObject bulletPtrfab;
    private GameObject bullet;

    private NavMeshAgent navMesh;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>(); 
        navMesh = GetComponent<NavMeshAgent>();
        navMesh.SetDestination(target.position);

    }

    // Update is called once per frame
    void Update()
    {
        navMesh.SetDestination(target.position);
        EnemyShoot();
    }

    public void ReactToHit()
    {
        gameManager.enemyList.Remove(gameObject);
        Destroy(gameObject);
        gameManager.EnemyCreater();

    }

    public void EnemyShoot()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.SphereCast(ray, 0.75f, out hit))
        {
            GameObject hitObject = hit.transform.gameObject;
            if (hitObject.GetComponent<Player>()) 
            {
                if (bullet==null)
                {
                    bullet = Instantiate(bulletPtrfab);
                    bullet.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                    bullet.transform.rotation = transform.rotation;
                }

            }
        }

    }
}
