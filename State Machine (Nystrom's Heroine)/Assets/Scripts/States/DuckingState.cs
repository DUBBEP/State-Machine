using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DuckingState : MonoBehaviour, IState
{
    private CharacterStateController _characterController;

    public void Handle(CharacterStateController characterController)
    {
        if (!_characterController)
            _characterController = characterController;

        GetComponent<Transform>().localScale = new Vector3 (1, _characterController.duckHeight, 1);
    }

    public void Exit() { GetComponent<Transform>().localScale = new Vector3(1, 1, 1); }

    public void UpdateState()
    {
        if (!_characterController)
            return;

        if (Input.GetKeyUp(KeyCode.S))
        {
            _characterController.Stand();
        }
        Debug.Log("DuckUpdate");

    }
}
