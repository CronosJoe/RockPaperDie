using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTileClass : MonoBehaviour
{
    //The map tile should contain if it is moveable or not, down the line it might also contain events to create obstacles
    private bool isWalkable; //I don't want this variable to be edited simply checked
    GameObject previousTile;
    public bool CheckWalkable() //simply returns the isWalkable variable
    {
        return isWalkable;
    }
}
