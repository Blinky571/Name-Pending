using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temporary_CameraScript : MonoBehaviour
{
    private GameObject player;
    private void Awake()
    {
        player = GameObject.Find("NewPlayer");
    }
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y +3, transform.position.z);  
    }
}
