using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position;
    }

    void LateUpdate()
    {
        if (player)
        {
            transform.position = player.transform.position + offset;
        }
    }
}
