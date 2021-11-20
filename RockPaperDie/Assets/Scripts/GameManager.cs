using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //At base the game manager needs to hold onto the map data and list of characters on the map
    [Header("Map Data")]
    [SerializeField] int mapWidth = 10;
    [SerializeField] int mapHeight = 10;
    Vector3Int mapStartingSpace = new Vector3Int(0, 0, 0); //later this variable will probably be put into a text document
    //Map data will be stored in this list, each tile will have the MapTileClass on it to store if it's walkable and everything else it might need
    GameObject[,] mapTiles; //going to default the map to a 10 by 10 grid, down the line I might want to have this generated
    [Header("BoardPieces")]
    //character list
    [SerializeField] List<GameObject> charactersOnBoard = new List<GameObject>(); // each character should handle their own data in their own scripts 
    //prefab data for instantiation
    [Header("Prefabs")]
    //map tiles
    [SerializeField] GameObject tileObject;
    //enemy prefab, add in once map spawning works
    //handle spawning everything into the scene, likely the spawning method will want location on the map for each character, these values can be stored in the list of characters

    // Start is called before the first frame update
    void Start()
    {
        //load the map size
        //An idea I had was adding files that have the map data on them to be pulled from
        //setting up the map 
        mapTiles = new GameObject[mapWidth, mapHeight];
        //here I will want to instantiate the board
        BuildingTheBoard(mapStartingSpace);
        //here I will want to instantiate the enemies
    }

    //Creating the board
    void BuildingTheBoard(Vector3Int startingLocation) 
    {
        for(int i = 0; i < mapHeight ; i++) 
        {
            for(int j = 0; j < mapWidth; j++) 
            {
                GameObject tmpObject = Instantiate(tileObject, startingLocation + new Vector3Int(j*2, 0,i*2), Quaternion.identity); //create the tile
                mapTiles[j, i] = tmpObject; //save the tile to the array
            }
        }
    }
}
