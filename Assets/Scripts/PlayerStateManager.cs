using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateManager : MonoBehaviour
{
    PlayerBaseState currentState;
    public PlayerNormalState NormalState = new PlayerNormalState(); //fps, canonballs | ->tps,canonbals -> fps,canonballs| ->, rockets
    public PlayerRocketState RocketState = new PlayerRocketState();//fps, rockets| -> tps, rockets->fps| -> mortars
    public PlayerMortarState MortarState = new PlayerMortarState();
    public PlayerCannonState CannonState = new PlayerCannonState();
    public PlayerThirdPersonState PlayerThirdPersonState = new PlayerThirdPersonState();

    public GyroCam MainCamera;
    public CharacterController controller;
    public Vector3 playerVelocity;
    public bool groundedPlayer;
    public float playerSpeed = 2.0f;
    public float jumpHeight = 1.0f;
    public float gravityValue = -9.81f;
    public PlayerInput input;
    public InputAction m_Move;
    public InputAction m_Look;
    public InputAction m_Fire;
    public InputAction m_Toggle;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Player Statrted");
        currentState = NormalState;
        currentState.EnterState(this);
        controller = GetComponent<CharacterController>();
        input = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }
    public void SwitchState(PlayerBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
