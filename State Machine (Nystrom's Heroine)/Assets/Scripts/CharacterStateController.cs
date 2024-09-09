using UnityEngine;

public class CharacterStateController : MonoBehaviour
{
    // character variables below
    public float jumpForce = 5.0f;
    public float diveSpeed = 5.0f;
    public float duckHeight = 0.5f;

    private IState
       _standingState, _jumpState, _diveState, _duckState;

    public Rigidbody rb;
    
    private StateContext _stateContext;
    private bool _isGrounded;

    private void Start()
    {
        _stateContext = new StateContext(this);
        rb = GetComponent<Rigidbody>(); 

        _standingState =
             gameObject.AddComponent<StandingState>();
        _jumpState =
             gameObject.AddComponent<JumpingState>();
        _diveState =
             gameObject.AddComponent<DivingState>();
        _duckState =
             gameObject.AddComponent<DuckingState>();


        _stateContext.Transition(_standingState);
    }

    public void Jump()
    {
        _stateContext.Transition(_jumpState);
        Debug.Log("Jumping");
    }
    public void Duck()
    {
        _stateContext.Transition(_duckState);
        Debug.Log("Ducking");

    }
    public void Dive()
    {
        _stateContext.Transition(_diveState);
        Debug.Log("Diving");

    }
    public void Stand()
    {
        _stateContext.Transition(_standingState);
        Debug.Log("Standing");

    }

    
    private void Update()
    {
        Debug.Log("Running InputChecks");



        if (_stateContext.CurrentState == _standingState && Input.GetKeyDown(KeyCode.S))
            Duck();
        if (_stateContext.CurrentState == _duckState && Input.GetKeyUp(KeyCode.S))
            Stand();
        if (_stateContext.CurrentState == _jumpState && Input.GetKeyDown(KeyCode.S))
            Dive();
        if (_stateContext.CurrentState == _standingState && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
            _isGrounded = false;
        }
        if (!_isGrounded && Physics.Raycast(transform.position, Vector3.down, 0.5f))
        {
            Stand();
            _isGrounded = true;
        }
    }
     
}
