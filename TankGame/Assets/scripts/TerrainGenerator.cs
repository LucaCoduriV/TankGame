﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{

    public Material material;

    public int terrainWidth = 10;
    public int terrainHeight = 2;

    public float heightMultiplier = 10;
    public int heightAddition = 0;
    public float smoothness = 10;

    public static TerrainGenerator instance = null;

    private float seed;
    private GameObject terrain;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }else if(instance != this)
        {
            Destroy(gameObject);
        }


        seed = Random.Range(-10000f, 10000f);
        CreateMesh();
    }

    private void Start()
    {
        
    }

    private void CreateMesh()
    {
        Vector3[] vertices = CreateVertices();
        Vector2[] uvs = CreateUvs();
        int[] triangles = CreateTriangles();


        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.uv = uvs;
        mesh.triangles = triangles;


        terrain = new GameObject("Terrain", typeof(MeshFilter), typeof(MeshRenderer));
        terrain.transform.localScale = new Vector3(1, 1, 1);
        terrain.transform.position = new Vector3(0, 0, 1);

        terrain.GetComponent<MeshFilter>().mesh = mesh;
        terrain.GetComponent<MeshRenderer>().material = material;
        terrain.GetComponent<MeshRenderer>().sortingLayerName = "foreground";

        ColliderCreator colliderCreator = terrain.AddComponent<ColliderCreator>();

        terrain.AddComponent<SpawnCreator>();


        CreateOutSideCollider(GetEdges());


    }
    private void Update()
    {
        
        
    }



    private Vector3[] CreateVertices()
    {
        Vector3[] vertices = new Vector3[terrainWidth * terrainHeight];
        

        for (int i = 0, y = 0; y < terrainHeight; y++)
        {
            for (int x = 0; x < terrainWidth; x++)
            {
                
                if(y == 0)
                {
                    vertices[i] = new Vector3(x, 0);
                }
                else
                {
                    float h = Mathf.PerlinNoise(seed, i / smoothness) * heightMultiplier + heightAddition;
                    vertices[i] = new Vector3(x, h);
                }
                
                i++;
            }
        }
        return vertices;
    }

    private Vector2[] CreateUvs()
    {
        Vector2[] uvs = new Vector2[terrainWidth * terrainHeight];

        for (int i = 0, y = 0; y < terrainHeight; y++)
        {
            for (int x = 0; x < terrainWidth; x++)
            {
                uvs[i] = new Vector2(x, y);
                i++;
            }
        }
        return uvs;
    }

    private int[] CreateTriangles()
    {
        int[] triangles = new int[terrainWidth * terrainHeight * 6];

        int vert = 0;
        int tris = 0;

        for (int y = 0; y < terrainHeight -1; y++)
        {
            for (int x = 0; x < terrainWidth - 1; x++)
            {
                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + terrainWidth;
                triangles[tris + 2] = vert + terrainWidth + 1;



                triangles[tris + 3] = vert + 0;
                triangles[tris + 4] = vert + terrainWidth + 1;
                triangles[tris + 5] = vert + 1;

                vert++;
                tris += 6;
            }
            vert++;
        }




        return triangles;
    }

    private void CreateOutSideCollider(Vector2[] edges)
    {
        terrain.AddComponent<EdgeCollider2D>();
        EdgeCollider2D edgeCollider = terrain.GetComponent<EdgeCollider2D>();
        terrain.GetComponent<EdgeCollider2D>().points = edges;
    }

    private Vector2[] GetEdges()
    {
        Vector2[] edges = new Vector2[5];

        edges[0] = new Vector2(terrain.transform.position.x, terrain.transform.position.y);
        edges[1] = new Vector2(terrainWidth, terrain.transform.position.y);
        edges[2] = new Vector2(terrainWidth,(float)(heightAddition + heightMultiplier));
        edges[3] = new Vector2(terrain.transform.position.x, (float)(heightAddition + heightMultiplier));
        edges[4] = edges[0];

        //TODO rajouter les min et max dans le tableau edges

        return edges;
    }
}
