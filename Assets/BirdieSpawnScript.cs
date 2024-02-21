using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdieSpawnScript : MonoBehaviour
{

    public GameObject birdie;
    public float spawnRate = 10;
    private float timer = 0;
    public float heightOffset = 10;

    // Start is called before the first frame update
    void Start()
    {
        spawnBirdie();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnBirdie();
            timer = 0;
        }
    }

    void spawnBirdie()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        Instantiate(birdie, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint)), transform.rotation);
    }
}
