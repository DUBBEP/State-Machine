using UnityEngine;

public class CharacterStateController : MonoBehaviour
{
    #region Variables
    // character variables below
    public float jumpForce = 5.0f;
    public float diveSpeed = 5.0f;
    public float duckHeight = 0.5f;
    public float walkSpeed = 5.0f;
    public float jumpingGravForce = 3f;
    public float fallingGravForce = 6f;

    private IState
       _standingState, _jumpState, _diveState, _duckState, 
                _moveState, _fallState, _bounceState, _unstablePositionState;

    public Rigidbody rb;
    public BoxCollider boxCollider;
    private StateContext _stateContext;

    #endregion

    #region Start
    private void Start()
    {
        _stateContext = new StateContext(this);
        rb = GetComponent<Rigidbody>(); 
        boxCollider = GetComponentInChildren<BoxCollider>();

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
        _fallState =
            gameObject.AddComponent<FallState>();
        _bounceState =
            gameObject.AddComponent<BounceState>();
        _unstablePositionState =
            gameObject.AddComponent<UnstablePositionState>();

        _stateContext.Transition(_standingState);
    }
    #endregion

    #region Transition Fuctions
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

    public void Fall()
    {
        _stateContext.Transition(_fallState);
        Debug.Log("Falling");
    }

    public void Bounce()
    {
        _stateContext.Transition(_bounceState);
        Debug.Log("Bouncing");
    }

    public void BecomeUnstable()
    {
        _stateContext.Transition(_unstablePositionState);
        Debug.Log("Becoming Unstable");
    }
    #endregion

    #region Updates
    private void Update()
    {
        _stateContext.HandleUpdate();
    }

    private void FixedUpdate()
    {
        _stateContext.HandlePhysics();
    }
    #endregion
}
