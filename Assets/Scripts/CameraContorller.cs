using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContorller : MonoBehaviour
{

    [SerializeField] private Transform player;
    // Update is called once per frame
    void Update()
    {
        //PlayerMovement.GlobalEvent = (int)Input.GetAxisRaw("Horizontal");
        //PlayerMovement.GlobalEventJump = Input.GetButtonDown("Jump");


        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
