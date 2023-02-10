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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector3(player.transform.position.x, player.transform.position.y +3, transform.position.z);
        
    }
}
