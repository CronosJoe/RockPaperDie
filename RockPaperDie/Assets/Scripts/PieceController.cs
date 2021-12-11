using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PieceController : MonoBehaviour
{
    //Create a state system to run through, move, check, resolve, accept all needed variables for these because the player and ai will both be using this
   public enum CurrentState 
    {
        Move, //this will move the character
        Check, //this will check nearby tiles for enemies
        Resolve, //this will resolve any conflicts by calling the mini game
        Wait //wait will be the default until the game manager changes it
    }
    public CurrentState currentState = CurrentState.Wait;
    public Vector2 currentTile = Vector2.zero;
    public GameManager gameManager;
    public abstract void MoveCharacter();
    public abstract GameObject[] CheckCharacter();
    public void SetPosition()  
    {
        transform.position = gameManager.mapTiles[(int)currentTile.x, (int)currentTile.y].transform.position; //might want to have an animation or something play here
    }
    public void ResolveConflicts(GameObject opponent) 
    {
        //Call the mini game fight using opponent as the player's enemy
    }
}
