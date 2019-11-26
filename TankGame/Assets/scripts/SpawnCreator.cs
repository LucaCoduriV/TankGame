using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCreator : MonoBehaviour
{
    private Vector2[] colliderPath;

    public float offSet = 1;

    private void Awake()
    {
 
    }

    // Start is called before the first frame update
    void Start()
    {
        Vector2 position = new Vector2(2, GetHeightForX(2));
        Debug.Log(position.y);
        position.y += offSet;

        GameObject.Find("Tank").transform.position = position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    float GetHeightForX(float x)
    {

        colliderPath = GetComponent<PolygonCollider2D>().GetPath(0);
        foreach (Vector2 vector in colliderPath)
        {
            if(vector.x == x && vector.y != 0)
            {
                return vector.y;
            }

        }

        return 0;
    }

}
