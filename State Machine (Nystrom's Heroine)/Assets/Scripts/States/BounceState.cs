using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceState : MonoBehaviour, IState
{
    private bool _bouncing = false;
    private float _zeroGravTime = 0f;

    private CharacterStateController _characterController;
    public void Exit()
    {
        _characterController.boxCollider.material.bounciness = 0;
        transform.rotation = Quaternion.identity;
        _characterController.rb.constraints |= RigidbodyConstraints.FreezeRotationZ;
        _bouncing = false;
        _characterController.rb.useGravity = true;

    }

    public void Handle(CharacterStateController characterController)
    {
        if (!_characterController)
            _characterController = characterController;

        _bouncing = true;

        _characterController.boxCollider.material.bounciness = 1;
        _characterController.rb.constraints &= ~RigidbodyConstraints.FreezeRotationZ;
        _characterController.rb.AddTorque(new Vector3(0, 0, 5), ForceMode.Impulse);
        Debug.Log("Handling Bounce");
    }

    public void PhysicsUpdate()
    {
        if (_zeroGravTime < 0)
        _characterController.rb.AddForce(Vector3.down * _characterController.fallingGravForce);
    }

    public void UpdateState()
    {
        if (Input.GetKeyDown(KeyCode.B))
            _characterController.Fall();

        if (_zeroGravTime > 0)
            _zeroGravTime -= Time.deltaTime;

        if (_zeroGravTime <= 0 && _characterController.rb.useGravity == false)
            _characterController.rb.useGravity = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!_bouncing)
            return;

        _zeroGravTime = 0.2f;
        _characterController.rb.useGravity = false;

        Debug.Log("Pause falling for extra bounce");
    }
}
