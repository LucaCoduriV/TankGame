using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{

    private bool isDead = false;
    PolygonCollider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void CheckIfGotHit()
    {
        
    }

    private void Die()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {

    }

}
