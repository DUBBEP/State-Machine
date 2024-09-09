using UnityEngine;

public class UnstablePositionState : MonoBehaviour, IState
{
    private CharacterStateController _characterController;
    private BoxCollider _teleportRange;
    private GameObject _camera;

    private Vector3 _cameraStartingPosition;
    private float _xmin, _xmax, _ymin, _ymax;

    public void Exit() 
    { 
        _characterController.rb.isKinematic = false;
        _camera.transform.position = _cameraStartingPosition;
    }

    public void Handle(CharacterStateController characterController)
    {
        if (!_characterController)
            _characterController = characterController;

        _teleportRange = GameObject.Find("TeleportBounds").GetComponent<BoxCollider>();
        _characterController.rb.isKinematic = true;
        _camera = Camera.main.gameObject;

        _cameraStartingPosition = _camera.transform.position;
        _xmin = _cameraStartingPosition.x - 0.1f;
        _xmax = _cameraStartingPosition.x + 0.1f;
        _ymin = _cameraStartingPosition.y - 0.1f;
        _ymax = _cameraStartingPosition.y + 0.1f;

    }

    public void PhysicsUpdate() { return;  }

    public void UpdateState()
    {
       MoveToRandomPosition(_teleportRange.bounds);
       ShakeCamera();

        if (Input.GetKeyDown(KeyCode.U))
            _characterController.Fall();
    }

    void MoveToRandomPosition(Bounds bounds)
    {
        _characterController.transform.position = new Vector3(
        Random.Range(bounds.min.x, bounds.max.x),
        Random.Range(bounds.min.y, bounds.max.y),
        0);
    }

    void ShakeCamera()
    {
        _camera.transform.position = new Vector3(
            Random.Range(_xmin, _xmax),
            Random.Range(_ymin, _ymax),
            _camera.transform.position.z);
    }
}
