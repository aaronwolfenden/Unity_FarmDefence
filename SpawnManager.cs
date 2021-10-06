using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 20;
    private float spawnPosZ = 20;
    private float startDelay = 2;
    private float spawnInterval = 2.0f;
    private int spawnPositionSelector = 0;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SpawnRandomAnimal();
        }
    }

    void SpawnRandomAnimal()
    {
        // Generate a random spawn position (middle / left / right) with an integer
        spawnPositionSelector = Random.Range(0, 3);


        // Randomly generate animal index and spawn position
        // Middle spawner
        if (spawnPositionSelector == 0) {
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
            int animalIndex = Random.Range(0, animalPrefabs.Length);

            Instantiate(animalPrefabs[animalIndex], spawnPos,
                animalPrefabs[animalIndex].transform.rotation);
        }
        // Left spawner
        else if (spawnPositionSelector == 1)
        {
            Vector3 spawnPos = new Vector3(-20, 0, Random.Range(5, 10));
            Quaternion spawnRotation = new Quaternion(0, 90, 0, 90);
            int animalIndex = Random.Range(0, animalPrefabs.Length);

            Instantiate(animalPrefabs[animalIndex], spawnPos,
                spawnRotation);
        }
        // Right spawner
        else if (spawnPositionSelector == 2)
        {
            Vector3 spawnPos = new Vector3(20, 0, Random.Range(5, 10));
            int animalIndex = Random.Range(0, animalPrefabs.Length);
            Quaternion spawnRotation = new Quaternion(0, -90, 0, 90);

            Instantiate(animalPrefabs[animalIndex], spawnPos,
                spawnRotation);

        }


    }
}
