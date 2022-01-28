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
    // Start is called before the first frame update
    void Start()
    {
        Input.gyro.enabled = true;
        input = GetComponent<PlayerInput>();
        camrot = transform.localRotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        camrot = Input.gyro.rotationRateUnbiased;
        Vector2 inputmove = input.actions["Look"].ReadValue<Vector2>();
        //mc.transform.Rotate(0, -Input.gyro.rotationRateUnbiased.y, 0);
        //this.transform.Rotate(-Input.gyro.rotationRateUnbiased.x, 0, 0);
        // float lookx = -Input.gyro.rotationRateUnbiased.x;
        //float looky = -Input.gyro.rotationRateUnbiased.y;

        // xrot -= looky;
        

        //transform.localRotation = Quaternion.Euler(xrot, 0f, 0f);
        xrot = Mathf.Clamp(xrot, -90f, 90f);
        this.transform.Rotate(-Input.gyro.rotationRateUnbiased.x, 0, 0);
        Body.Rotate(0,-Input.gyro.rotationRateUnbiased.y,0);
    }
}
