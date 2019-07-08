using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject enemyCars;
    public GameObject barrels;

    public Vector3 center;
    public Vector3 size;

    //current time
    private float time;
    private float timeBarrels;

    //The time to spawn the object
    private float spawnTimeEnemies;
    public float minTimeEnemies=1f;
    public float maxTimeEnemies=10f;
    private float spawnTimeBarrels;
    public float minTimeBarrels=1f;
    public float maxTimeBarrels=10f;

    // Start is called before the first frame update
    void Start()
    {
        center = transform.position;
        size = transform.localScale;
        //spawnEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            spawnEnemies();
        }
    }

    private void FixedUpdate()
    {
        //Counts up
        time += Time.deltaTime;
        timeBarrels += Time.deltaTime;
        //Check if its the right time to spawn the object
        if (time >= spawnTimeEnemies)
        {
            spawnEnemies();
            SetRandomTimeEnemies();
        }
        if(timeBarrels >= spawnTimeBarrels)
        {
            spawnBarrels();
            SetRandomTimeBarrels();
        }
    }

    public void spawnEnemies()
    {
        time = 0;
        Vector3 pos_enemy = center + new Vector3(Random.Range(-size.x / 2, size.x /2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
        Instantiate(enemyCars, pos_enemy, Quaternion.identity);
    }

    public void spawnBarrels()
    {
        timeBarrels = 0;
        Vector3 pos_barrel = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
        Instantiate(barrels, pos_barrel, Quaternion.identity);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, size);
    }

    void SetRandomTimeEnemies()
    {
        spawnTimeEnemies = Random.Range(minTimeEnemies, maxTimeEnemies);
    }

    void SetRandomTimeBarrels()
    {
        spawnTimeBarrels = Random.Range(minTimeBarrels, maxTimeBarrels);
    }
}
