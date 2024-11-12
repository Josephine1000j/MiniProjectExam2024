using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    private Transform player;


    private float yOffset = 4.5f;
    private float zOffset = -6f;
   


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(player.position.x,player.position.y + yOffset, player.position.z + zOffset);

        Debug.Log(transform.position);
    }
}
