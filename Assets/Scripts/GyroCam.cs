using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GyroCam : MonoBehaviour
{
  
    public Transform Body;
    public PlayerInput input;
    public float sensitivitiy = 100.0f;
    public float xrot = 0f;
    public Vector3 camrot;
    public PlayerControl inputactions;
    public bool isFPS = true;
    public int battery = 100;
    public float distanceToTank = 50;
    public bool isTeathered = true;
    
    public CameraBaseState currecntcamState;
    public CamFPSState C_FPS_State = new CamFPSState();
   
    //drone tps mode
    public CamNormalState C_NormalState = new CamNormalState();
    public CamRocketState C_RocketState = new CamRocketState();
    public CamMortarState C_MortarState = new CamMortarState();
    public CamUnhookedState C_UnhookedState = new CamUnhookedState();
    public CamDisabledState C_DisabledState = new CamDisabledState();

    private void ToggleCamPosition()
    {
        Debug.Log("Switching camera view");
      
    }

    private void Awake()
    {
        input = GetComponent<PlayerInput>();
        inputactions = new PlayerControl();
        inputactions.Player.Toggle.performed += contex => ToggleCamPosition();
    }

    // Start is called before the first frame update
    void Start()
    {
        Input.gyro.enabled = true;
        inputactions.Enable();
        camrot = transform.localRotation.eulerAngles;
        Debug.Log("FPS cam State");
        currecntcamState = C_FPS_State;
        currecntcamState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        //float v = -Input.gyro.rotationRateUnbiased.x;
        //camrot.x += v;
        //Vector2 inputmove = input.actions["Look"].ReadValue<Vector2>();
        //mc.transform.Rotate(0, -Input.gyro.rotationRateUnbiased.y, 0);
        //this.transform.Rotate(-Input.gyro.rotationRateUnbiased.x, 0, 0);
        // float lookx = -Input.gyro.rotationRateUnbiased.x;
        //float looky = -Input.gyro.rotationRateUnbiased.y;

        // xrot -= looky;


        //transform.localRotation = Quaternion.Euler(xrot, 0f, 0f);
        //xrot = Mathf.Clamp(xrot, -90f, 90f);
        //this.transform.Rotate(-Input.gyro.rotationRateUnbiased.x - inputmove.y, 0f, 0f);
        //Body.Rotate(0f,-Input.gyro.rotationRateUnbiased.y + inputmove.x,0f);

        //check state
        currecntcamState.UpdateState(this);

        //brakeys FPS TUT
      
    }
    public void SwitchState(CameraBaseState state)
    {
        currecntcamState = state;
        state.EnterState(this);
    }
}
