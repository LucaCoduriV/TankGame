using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCreator : MonoBehaviour
{
    public List<Vector2> spawnList = new List<Vector2>();
    public static SpawnCreator instance = null;
    public float offSet = 1;

    private float meshWidth;
    private Vector2[] colliderPath;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        colliderPath = GetComponent<PolygonCollider2D>().GetPath(0);
        meshWidth = GetMeshWidth();
        spawnList = getSpawns();
    }

    
    //Permet d'avoir la taille du mesh
    public float GetMeshWidth()
    {
        float max = 0;

        foreach (Vector2 vector in colliderPath)
        {
            max = vector.x > max ? vector.x : max;
        }

        return max + 1;
    }

    //permet d'avoir le Y en fonction de X;
    public float GetHeightForX(float x)
    {
        foreach (Vector2 vector in colliderPath)
        {
            if(vector.x == x && vector.y != 0)
            {
                return vector.y;
            }

        }

        return 0;
    }
    //permet d'avoir la liste des spawn disponible pour le mesh
    public List<Vector2> getSpawns()
    {
        List<Vector2> spawnList = new List<Vector2>();


        for (int i = 0; i < meshWidth; i++)
        {
            spawnList.Add(new Vector2(i, GetHeightForX(i) + offSet));
        }

        return spawnList;
    }

}
