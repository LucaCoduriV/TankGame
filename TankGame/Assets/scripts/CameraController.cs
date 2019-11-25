using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject camera;
    GameObject playerOne;
    Vector3 camPos;


    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("Camera");
        playerOne = GameObject.Find("Tank");
    }

    // Update is called once per frame
    void Update()
    {
        camPos = playerOne.transform.position;
        camPos.z = camera.transform.position.z;

        camera.transform.position = camPos;
    }
}
