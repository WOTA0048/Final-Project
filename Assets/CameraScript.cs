using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private Rigidbody2D rb2d;

    // Use this for initialization
    void Start()
    {
        
    }

    

    public Transform player;
    public Vector3 offset;

    public bool border;
    public float minX;
    public float maxX;

    public float minY;
    public float maxY;

    void Update()
    {
        //transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z); // Camera follows the player with specified offset position
        transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, player.position.z + offset.z);
        if (border == true)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX),
                                             Mathf.Clamp(transform.position.y, minY, maxY),
                                             transform.position.z);
        }



    }

    void FixedUpdate()
    {
        
    }


}

