﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    [SerializeField] private int width_ , height_;
    [SerializeField] private Tile tilePrefab_;
    [SerializeField] private Transform cam_;
    [SerializeField] private Vector3[] points;

    private Dictionary<Vector2, Tile> all_tiles;

    private void Start()
    {
        generateGrid();
    }
    private void generateGrid()
    {
        all_tiles = new Dictionary<Vector2, Tile>();
        for (int x = 0; x < width_; x++)
        {
            for (int y = 0; y < height_; y++)
            {
                var spawnedTile = Instantiate(tilePrefab_,new Vector3(x,y),Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";

                var isOffset = (x % 2 != 0 && y % 2 == 0) || (x%2==0&& y %2!=0); // different colorization
                spawnedTile.Init(isOffset);

                all_tiles[new Vector2(x, y)] = spawnedTile;

            }
        }

        cam_.transform.position = new Vector3((float)width_/2 -0.5f,(float)height_/2-0.5f,-10);
    }

    public Tile getTileAtPosition(Vector2 pos) // if the tile is avaliable we will simply return that tile, otherwise null. For getting tile at current position
    {
        if (all_tiles.TryGetValue(pos, out var tile))
        {
            return tile;
        }

        return null;
        
    }

    private void OnDrawGizmos() // a line should be drawn by one position to next position in path, except the last position since it will not have a next position 
    {
        for (int i = 0; i < width_; i++)
        {
            for (int k = 0; k < height_; k++)
            {
                Gizmos.color = Color.green;
                Vector2 pos = new Vector2(i,k);
                Gizmos.DrawSphere(pos, 0.08f);
            }
        }
        

    }
 }
