using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    [SerializeField] private int width_ , height_;
    [SerializeField] private Tile tilePrefab_;
    [SerializeField] private Transform cam_;

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
}
