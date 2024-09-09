using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAirState : MonoBehaviour
{
    public void BasicAirStateChecks(CharacterStateController characterController)
    {
        // allow bounce
        if (Input.GetKeyDown(KeyCode.B))
            characterController.Bounce();

        // check for ground
        if (Physics.CheckBox(transform.position + new Vector3(0, -0.11f, 0),
                                            new Vector3(0.2f, 0.1f, 0.2f), Quaternion.identity))
            characterController.Stand();
    }
}
