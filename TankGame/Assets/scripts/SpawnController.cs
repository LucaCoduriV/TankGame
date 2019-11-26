using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    private List<Vector2> spawnList;
    public static SpawnController instance = null;

    public List<Vector2> SpawnList { get => spawnList;}

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

    private void Start()
    {
        spawnList = SpawnCreator.instance.getSpawns();
        Vector2 playerSpawn = spawnList[0];
        Debug.Log(playerSpawn);
        GameObject.Find("Tank").transform.position = playerSpawn;
    }
}
