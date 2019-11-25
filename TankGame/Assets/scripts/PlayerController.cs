using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public PlayerController2D pc;


    private void Start()
    {
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(Input.GetAxisRaw("Horizontal") == 1)
        {
            pc.Move(1,false,false);
        }
        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            pc.Move(-1, false, false);
        }
        if (Input.GetKeyDown("space"))
        {
            pc.Move(1, false, true);
        }
    }
}