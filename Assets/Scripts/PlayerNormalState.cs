
using System;
using UnityEngine;

public class PlayerNormalState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager PSM)
    {
        //throw new System.NotImplementedException();
        //camera fps
        //cannon
        Debug.Log("Entering Normal State");
        
    }

    public override void OnCollisionEnter(PlayerStateManager PSM, Collision collision)
    {
        Debug.Log("Collision State entered in Normal State");
        throw new System.NotImplementedException();
    }

    public override void UpdateState(PlayerStateManager PSM)
    {
        Vector2 inputmove = PSM.input.actions["Move"].ReadValue<Vector2>();
        PSM.groundedPlayer = PSM.controller.isGrounded;
        if (PSM.groundedPlayer && PSM.playerVelocity.y < 0)
        {
            PSM.playerVelocity.y = -1f;
        }

        PSM.playerVelocity.y += PSM.gravityValue * Time.deltaTime;

        float x = inputmove.x;
        float z = inputmove.y;

        Vector3 move = PSM.transform.right * x + PSM.transform.forward * z;
        PSM.controller.Move(move * PSM.playerSpeed * Time.deltaTime);

        if (PSM.input.actions["Toggle"].WasPressedThisFrame())
        {
            if (PSM.MainCamera.isFPS)
            {
                Debug.Log("Toggling state change from Normal to TPS");
                PSM.MainCamera.SwitchState(PSM.MainCamera.C_NormalState);
            }
            else
            {
                Debug.Log("Toggling State change from TPS to Normal");
                PSM.MainCamera.SwitchState(PSM.MainCamera.C_FPS_State);
            }

        }

        if (PSM.input.actions["Fire"].WasPerformedThisFrame())
        {
            fps_fire();
        }
    }

    private void fps_fire()
    {

    }
}
