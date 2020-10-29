using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MouseHandling : MonoBehaviour
{
    public Tilemap tilemap;
    
    TileBase tile;
    public TileBase lightGreenTile;
    public TileBase darkGreenTile;
    
    public Grid grid;

    public bool isOnLawn;
    public Vector3 mousePos;
    public Vector3Int posInt;
    //public Sprite sprite;
    // Start is called before the first frame update
    void Start()
    {
        isOnLawn = false;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.x += 0.5f;
        mousePos.y += 0.5f;
        posInt = grid.WorldToCell(mousePos);
        tile = tilemap.GetTile(posInt);

        if(tile == lightGreenTile || tile == darkGreenTile)
        {
            isOnLawn = true;
        }
        else
        {
            isOnLawn = false;
        }
    }
}
