using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerScript : MonoBehaviour
{

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    public float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    private PlayerInput input;
    private InputAction m_Move;
    private InputAction m_Look;
    private InputAction m_Fire;
    private InputAction m_Toggle;
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        input = GetComponent<PlayerInput>();
    }


    void Update()
    {

        Vector2 inputmove = input.actions["Move"].ReadValue<Vector2>();
        //    //Debug.Log(inputmove.ToString());
            groundedPlayer = controller.isGrounded;
            if (groundedPlayer && playerVelocity.y < 0)
            {
                playerVelocity.y = -1f;
            }

        //    //Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //    Vector3 move = new Vector3(inputmove.x, 0, inputmove.y);
        //    controller.Move(move * Time.deltaTime * playerSpeed);

        //    if (move != Vector3.zero)
        //    {
        //        gameObject.transform.forward = move;
        //    }

        //    // Changes the height position of the player..
        //    if (Input.GetButtonDown("Jump") && groundedPlayer)
        //    {
        //        playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        //    }

        playerVelocity.y += gravityValue * Time.deltaTime;
        //    controller.Move(playerVelocity * Time.deltaTime);

        //brakey's fprtutorial
        float x = inputmove.x;
        float z = inputmove.y;

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * playerSpeed * Time.deltaTime);


    }
}
