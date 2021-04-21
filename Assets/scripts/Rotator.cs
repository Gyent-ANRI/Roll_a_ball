using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    private Vector3 rotate;
    // Start is called before the first frame update
    void Start()
    {
        rotate = new Vector3(15, 30, 45);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotate * Time.deltaTime);
    }
}
