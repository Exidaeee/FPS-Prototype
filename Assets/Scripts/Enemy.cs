using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform target;
    private GameManager gameManager;

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
    }

    public void ReactToHit()
    {
        gameManager.enemyList.Remove(gameObject);
        Destroy(gameObject);
        gameManager.EnemyCreater();

    }
}
