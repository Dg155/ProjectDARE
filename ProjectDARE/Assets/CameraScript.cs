using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    void Update()
    {
        this.transform.position = GameObject.FindWithTag("Player").transform.position + new Vector3(0, 1, -5);;
    }
}
