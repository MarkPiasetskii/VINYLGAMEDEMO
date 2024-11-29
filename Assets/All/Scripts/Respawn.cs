using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject player;
    public Transform respawnPoint;
    



    void Start()
        {

        }
    void Update()
        {

        }

    void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.tag == "Player")
                {
                    player.transform.position = respawnPoint.position;
                }


        }
}
