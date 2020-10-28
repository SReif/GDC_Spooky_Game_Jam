using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MouseHandling : MonoBehaviour
{
    public Tilemap tilemap;
    
    TileBase tile;
    public TileBase greenTile;
    
    public Grid grid;

    public Sprite sprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int posInt = grid.LocalToCell(mousePos);
        tile = tilemap.GetTile(posInt);
        tilemap.SetColor(posInt, Color.white);

        
    }

    void spawnPlant()
    {
        
    }

}
