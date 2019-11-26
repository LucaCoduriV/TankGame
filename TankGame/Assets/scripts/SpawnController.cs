using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    List<Vector2> spawnList;

    private void Start()
    {
        spawnList = SpawnCreator.instance.getSpawns();
        foreach (Vector2 spawn in spawnList)
        {
            Debug.Log(spawn.x + ";" + spawn.y);
        }
    }
}
