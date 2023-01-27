using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public float StartTime;
    private float TimeBetweenSpawn;
    public Transform[] Points;
    public GameObject[] CloudPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        TimeBetweenSpawn = StartTime;
    }

    // Update is called once per frame
    void Update()
    {
        int RandomPrefab = Random.Range(0, CloudPrefabs.Length);
        int RandomPoints = Random.Range(0, Points.Length);
        if (TimeBetweenSpawn <= 0)
        {
            Instantiate(CloudPrefabs[RandomPrefab], Points[RandomPoints].position, Quaternion.identity);
            TimeBetweenSpawn = StartTime;
        }
        else
        {
            TimeBetweenSpawn -= Time.deltaTime;
        }
    }
}
