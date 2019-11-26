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

        SetPlayerSpawn();
        SetAISpawn();
        
    }

    private void SetPlayerSpawn()
    {
        Vector2 playerSpawn = spawnList[5];
        GameObject.FindGameObjectsWithTag("Player")[0].transform.position = playerSpawn;
    }

    private void SetAISpawn()
    {
        int index = 0;

        foreach(GameObject AI in GameObject.FindGameObjectsWithTag("AI"))
        {
            AI.transform.position = spawnList[spawnList.Count - 3 - index];
            index += 5;
        }

        Vector2 AISpawn = spawnList[5];
        GameObject.FindGameObjectsWithTag("Player")[0].transform.position = AISpawn;
    }

}
