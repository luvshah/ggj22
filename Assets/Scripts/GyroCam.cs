using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GyroCam : MonoBehaviour
{
  
    public Transform Body;
    private PlayerInput input;
    public float sensitivitiy = 100.0f;
    private float xrot = 0f;
    private Vector3 camrot;
    public PlayerControl inputactions;
    public bool isFPS = true;

    private void ToggleCamPosition()
    {
        Debug.Log("Switching camera view");
        isFPS = false;
    }

    private void Awake()
    {
        input = GetComponent<PlayerInput>();
        inputactions.Player.Toggle.performed += contex => ToggleCamPosition();
    }

    // Start is called before the first frame update
    void Start()
    {
        Input.gyro.enabled = true;
        inputactions.Enable();
        camrot = transform.localRotation.eulerAngles;
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


        //brakeys FPS TUT
        float joystickX = input.actions["Look"].ReadValue<Vector2>().x * sensitivitiy *Time.deltaTime;
        float joystickY = input.actions["Look"].ReadValue<Vector2>().y * sensitivitiy *Time.deltaTime;

        xrot -= joystickY;

        transform.localRotation = Quaternion.Euler(xrot, 0F, 0F);
        xrot = Mathf.Clamp(xrot, -90f, 90f);
        Body.Rotate(Vector3.up * joystickX);
    }
}
