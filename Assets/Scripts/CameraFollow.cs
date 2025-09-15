using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject player;
    private Vector3 cameraPosition = new Vector3(-3.08f, 13.75f, 1.14f);
    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + cameraPosition; 
        
    }
}
