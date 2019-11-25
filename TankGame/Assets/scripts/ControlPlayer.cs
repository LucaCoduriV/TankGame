using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MyPlayerController2D))]
public class ControlPlayer : MonoBehaviour
{
    public KeyCode keyCannonUp = KeyCode.UpArrow;
    public KeyCode keyCannondown = KeyCode.DownArrow;
    public KeyCode keyGoRight = KeyCode.RightArrow;
    public KeyCode keyGoLeft = KeyCode.LeftArrow;
    public KeyCode keyShoot = KeyCode.Space;

    private MyPlayerController2D playerController;
    

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<MyPlayerController2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            playerController.GoRight();
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            playerController.GoLeft();
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            playerController.CannonUp();
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            playerController.CannonDown();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerController.shoot();
        }
    }
}
