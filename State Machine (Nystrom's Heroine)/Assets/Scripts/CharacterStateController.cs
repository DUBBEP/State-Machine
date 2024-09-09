using UnityEngine;

public class CharacterStateController : MonoBehaviour
{
    // character variables below
    public float jumpForce = 5.0f;
    public float diveSpeed = 5.0f;
    public float duckHeight = 0.5f;
    public float walkSpeed = 5.0f;

    private IState
       _standingState, _jumpState, _diveState, _duckState, _moveState;

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
        _moveState =
             gameObject.AddComponent<MoveState>();


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

    public void Move()
    {
        _stateContext.Transition(_moveState);
        Debug.Log("Standing");

    }


    private void Update()
    {
        _stateContext.HandleUpdate();
    }
     
}
