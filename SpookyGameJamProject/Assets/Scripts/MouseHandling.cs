using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Tilemaps;

public class MouseHandling : MonoBehaviour
{
    public Tilemap tilemap;
    
    TileBase tile;

    
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
        posInt = grid.WorldToCell(mousePos);
        tile = tilemap.GetTile(posInt);
        double x = System.Math.Floor((mousePos.x / 2)) * 2 + 1;
        double y = System.Math.Round(mousePos.y / 2) * 2 ;
        posInt.x = (int)x;
        posInt.y = (int)y;

        if(x > -9 && x < 9 && y <= 2 && y >= -2 && tile != null)
        {
            isOnLawn = true;
        }
        else
        {
            isOnLawn = false;
        }
    }
}
