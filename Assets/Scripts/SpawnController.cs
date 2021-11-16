using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{

    [SerializeField] private float startTime = 4f;
    [SerializeField] private float cooldown = 5f;
    [SerializeField] private GameObject enemy;
    [SerializeField] private bool isActive = false;
    [SerializeField] private bool isFunctional = true;
    [SerializeField] private float detectionRange = 30f;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        InvokeRepeating("SpawnEnemy", startTime, cooldown); 
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerDirection = GetPlayerDirection();
        UpdateRange(playerDirection);
    }

    private void SpawnEnemy()
    {
        if (isActive && isFunctional)
        {
            Instantiate(enemy, transform.position, enemy.transform.rotation);
        }
    }

    private void UpdateRange(Vector3 playerDirection)
    {
        if (playerDirection.magnitude < detectionRange)
        {
            isActive = true;
        }
    }
    private Vector3 GetPlayerDirection()
    {
        return player.transform.position - transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isFunctional = false;
        }
    }
}
