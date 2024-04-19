using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarSpawnerScript : MonoBehaviour
{
    public GameObject pillar;
    public float spawnRate = 2;
    private float spawnTimer = 0;
    public float heighOffSet = 2;
    // Start is called before the first frame update
    void Start()
    {
        spawnPillar();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer < spawnRate)
        {
            spawnTimer += Time.deltaTime;
        }
        else
        {
            spawnPillar();
            spawnTimer = 0;
        }
    }
    
    void spawnPillar()
    {
        float lowestPoint = transform.position.y - heighOffSet;
        float highestPoint = transform.position.y + heighOffSet;
        Instantiate(pillar, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}
