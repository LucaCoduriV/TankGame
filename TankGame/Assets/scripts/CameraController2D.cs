using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController2D : MonoBehaviour
{
    GameObject camera;
    Renderer playerOne;
    Vector3 camPos;


    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("Camera");
        playerOne = GameObject.Find("Terrain").GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        camPos = playerOne.bounds.center;
        camPos.z = camera.transform.position.z;

        camera.transform.position = camPos;
    }
}
