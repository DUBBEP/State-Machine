using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivingState : MonoBehaviour, IState
{
    private CharacterStateController _characterController;

    public void Handle(CharacterStateController characterController)
    {
        if (!_characterController)
            _characterController = characterController;
        
        _characterController.rb.velocity = new Vector3(_characterController.rb.velocity.x, 0, _characterController.rb.velocity.z);
        _characterController.rb.AddForce(Vector3.down * _characterController.diveSpeed, ForceMode.Impulse);
    }

    public void Exit() { return; }


    public void UpdateState()
    {
        if (!_characterController)
            return;

        if (Physics.CheckBox(transform.position + new Vector3(0, -0.11f, 0),
                                                    new Vector3(0.2f, 0.1f, 0.2f), Quaternion.identity))
            _characterController.Stand();
        Debug.Log("DiveUpdate");
    }

    public void PhysicsUpdate() { return; }

}
