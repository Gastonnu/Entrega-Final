using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float speed = 0.5f;
    [SerializeField] private int damage = 20;
    [SerializeField] private bool isInRange = false;
    [SerializeField] private float detectionRange = 25f;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerDirection = GetPlayerDirection();
        UpdateRange(playerDirection);
        if(isInRange)
        {
            Rotate(playerDirection);
            MoveTowards(playerDirection);
        }
        
    }

    private void MoveTowards(Vector3 playerDirection)
    {
        
        Vector3 direction = new Vector3(playerDirection.x, 0, playerDirection.z);
        transform.position += direction * speed * Time.deltaTime;
    }

    private void Rotate(Vector3 playerDirection)
    {
        Quaternion newRotation = Quaternion.LookRotation(new Vector3(playerDirection.x, 0, playerDirection.z));
        transform.rotation = newRotation;
    }

    private void UpdateRange(Vector3 playerDirection)
    {
        if(playerDirection.magnitude < detectionRange)
        {
            isInRange = true;
        }
    }

    private Vector3 GetPlayerDirection()
    {
        return player.transform.position - transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet")){
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }

}
