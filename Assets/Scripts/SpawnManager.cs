using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstacles = new GameObject[3];
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float startDelay = 2f;
    private float repeatRate = 2f;
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating(nameof(SpawnObstacle), startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        // if (playerController.gameOver)
            // CancelInvoke(nameof(SpawnObstacle));
    }

    void SpawnObstacle()
    {
        if (!playerController.gameOver)
        {
            var obstacle = obstacles[Random.Range(0, obstacles.Length)];
            Instantiate(obstacle, spawnPos, obstacle.transform.rotation);
        }
    }
}
