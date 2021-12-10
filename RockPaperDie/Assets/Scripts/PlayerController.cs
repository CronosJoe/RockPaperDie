using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class PlayerController : CharacterController
{
    //This will be used for the different inputs that the user can have before the move state is finished
    enum inputs 
    {
        Up,
        Down,
        Left,
        Right
    }
    //the players input map
    public PlayerInput input;
    //storing the user's current input since they can only move once per move action
    inputs currentInput;
    
    //enabling all of our input events
    private void OnEnable()
    {
        input.currentActionMap["UP"].performed += MoveUp;
        input.currentActionMap["DOWN"].performed += MoveDown;
        input.currentActionMap["LEFT"].performed += MoveLeft;
        input.currentActionMap["RIGHT"].performed += MoveRight;
        input.currentActionMap["ActionConfirmation"].performed += MovementConfirmed;
    }
    //making sure to disable all our input events
    private void OnDisable()
    {
        try
        {
            input.currentActionMap["UP"].performed -= MoveUp;
            input.currentActionMap["DOWN"].performed -= MoveDown;
            input.currentActionMap["LEFT"].performed -= MoveLeft;
            input.currentActionMap["RIGHT"].performed -= MoveRight;
            input.currentActionMap["ActionConfirmation"].performed -= MovementConfirmed;
        }
        catch (NullReferenceException)
        {
            Debug.LogWarning("Failed to unsubscribe from the input event methods due to the input manager being removed first", this);
        }
    }
    private void MoveUp(InputAction.CallbackContext obj) 
    {
        if (currentState == CurrentState.Move)
            currentInput = inputs.Up;    
    }
    private void MoveDown(InputAction.CallbackContext obj)
    {
        if (currentState == CurrentState.Move)
            currentInput = inputs.Down;
    }
    private void MoveLeft(InputAction.CallbackContext obj)
    {
        if (currentState == CurrentState.Move)
            currentInput = inputs.Left;
    }
    private void MoveRight(InputAction.CallbackContext obj)
    {
        if (currentState == CurrentState.Move)
            currentInput = inputs.Right;
    }
    private void MovementConfirmed(InputAction.CallbackContext obj)
    {
        if (currentState == CurrentState.Move)
        {
            currentState = CurrentState.Check;
            MoveCharacter();
        }
    }
    public override void MoveCharacter()
    {
        //the user is now in the check state their input won't do anything during this state
        //take the current input and current tile then move in the given direction
        throw new System.NotImplementedException();
    }
    public override GameObject[] CheckCharacter()
    {
        throw new System.NotImplementedException();
    }
}

