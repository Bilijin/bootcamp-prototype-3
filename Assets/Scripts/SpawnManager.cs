using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obsPrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", 2.0f, 2.0f);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        if(!playerController.isGameOver)
        {
            Instantiate<GameObject>(obsPrefab, spawnPos, obsPrefab.transform.rotation);
        }
        
    }
}
