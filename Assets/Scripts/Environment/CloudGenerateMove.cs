using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGenerateMove : MonoBehaviour
{
    [Tooltip("The Prefab to be spawned into the scene.")]
    public GameObject spawnPrefab = null;

    [Tooltip("The time between spawns")]
    public float spawnTime = 500f;

    [Tooltip("The time between spawns")]
    public float moveSpeed = 30f;

    [Tooltip("The angle of the spawn prefab")]
    public float rotateAngle = 90f;

    // keep track of time passed for next spawn
    private float nextSpawn = 0f;

    // the record of current prefab object
    private GameObject currentPrefab = null;
    private Quaternion cloudRotation;

    // Start is called before the first frame update
    void Start()
    {
        cloudRotation = Quaternion.Euler(0, rotateAngle, 0);
        GameObject projectileGameObject = Instantiate(spawnPrefab, transform.position, cloudRotation, this.transform);
        currentPrefab = projectileGameObject;
    }

    // Update is called once per frame
    void Update()
    {
        // update the time until nextSpawn
        nextSpawn += Time.deltaTime;

        // if time to spawn
        if (nextSpawn > spawnTime)
        {
            if (currentPrefab)
            {
                Destroy(currentPrefab);
            }

            // Spawn the gameObject at the spawners current position and rotation
            GameObject projectileGameObject = Instantiate(spawnPrefab, transform.position, cloudRotation, this.transform);
            currentPrefab = projectileGameObject;

            // reset the time until nextSpawn
            nextSpawn = 0f;
        }

        else
        {
            currentPrefab.transform.Translate(Vector3.forward*moveSpeed * Time.deltaTime, Space.World);
        }


    }
}
