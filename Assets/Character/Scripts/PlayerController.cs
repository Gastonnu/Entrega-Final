using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private Animator animPlayer;

    private float cameraAxisX = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        RotatePlayer();
    }

    private void Move()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        AnimatorController(vertical, horizontal);
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void RotatePlayer()
    {
        cameraAxisX += Input.GetAxis("Mouse X");
        Quaternion angle = Quaternion.Euler(0, cameraAxisX, 0);
        transform.localRotation = angle;
    }

    private void AnimatorController(float vertical, float horizontal)
    {
        if (vertical == 0)
        {
            animPlayer.SetBool("isGoingForward", false);
            animPlayer.SetBool("isGoingBackward", false);
        }
        if (vertical > 0)
        {
            animPlayer.SetBool("isGoingForward", true);
        }
        if (vertical < 0)
        {
            animPlayer.SetBool("isGoingBackward", true);
        }
        if (horizontal == 0)
        {
            animPlayer.SetBool("isStrafingLeft", false);
            animPlayer.SetBool("isStrafingRight", false);
        }
        if (horizontal > 0)
        {
            animPlayer.SetBool("isStrafingLeft", true);
        }
        if (horizontal < 0)
        {
            animPlayer.SetBool("isStrafingRight", true);
        }
    }



}
