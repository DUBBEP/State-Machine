using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseGroundState : MonoBehaviour
{
    public void FallCheck(CharacterStateController characterController)
    {
        if (characterController.rb.velocity.y < 0)
        {
            if (!Physics.CheckBox(transform.position + new Vector3(0, -0.11f, 0),
                                                            new Vector3(0.4f, 0.1f, 0.2f), Quaternion.identity))
                characterController.Fall();
        }
    }
}
