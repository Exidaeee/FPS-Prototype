using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform player;
    private int enemyCounter = 10;
    public List<GameObject> enemyList;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyList = new List<GameObject>();
        for (int i = 0; i < enemyCounter; i++)
        {
            Vector3 pos = new Vector3(
                Random.Range(-30f, 80f),
                0f,
                Random.Range(-85f, 60f));
            if (NavMesh.SamplePosition(pos,out NavMeshHit hit, 10f, NavMesh.AllAreas))
            {
               GameObject enemy = Instantiate(enemyPrefab, hit.position, Quaternion.identity); //поворот как в префабе
               Enemy scriptEnemy = enemy.GetComponent<Enemy>(); // 
               scriptEnemy.target = player;
               enemyList.Add(enemy);
            }

        }    
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GameOver()
    {
        Debug.Log("Game Over");

    }    

    public void EnemyCreater()
    {
        Vector3 pos = new Vector3(
            Random.Range(-20f, 20f),
            0f,
            Random.Range(-20f, 20f));
        if(NavMesh.SamplePosition(pos, out NavMeshHit hit, 10f,NavMesh.AllAreas))
        {
            GameObject enemy = Instantiate(enemyPrefab, hit.position, Quaternion.identity);
            Enemy scriptEnemy = enemy.GetComponent<Enemy>(); // 
            scriptEnemy.target = player;

            enemyList.Add(enemy);
        }

    }
}
