using UnityEngine;
public class CamFPSState : CameraBaseState
{
    public override void EnterState(GyroCam CSM)
    {
        Debug.Log("Entering FPS State");

        CSM.isFPS = true;
        CSM.transform.SetParent(CSM.Body);
        CSM.transform.position = CSM.Body.transform.position;
        CSM.transform.rotation = CSM.Body.transform.rotation;

        GameObject.Find("tps_turret").GetComponentInChildren<Renderer>().enabled = false;
        GameObject.Find("t_barrel").GetComponentInChildren<Renderer>().enabled = false;
        GameObject.Find("fps_turret").GetComponentInChildren<Renderer>().enabled = true;
        GameObject.Find("f_barrel").GetComponentInChildren<Renderer>().enabled = true;
    }

    public override void OnCollisionEnter(GyroCam CSM, Collision collision)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(GyroCam CSM)
    {
        float joystickX = CSM.input.actions["Look"].ReadValue<Vector2>().x - Input.gyro.rotationRateUnbiased.y * CSM.sensitivitiy * Time.deltaTime;
        float joystickY = CSM.input.actions["Look"].ReadValue<Vector2>().y + Input.gyro.rotationRateUnbiased.x * CSM.sensitivitiy * Time.deltaTime;

        CSM.xrot -= joystickY;

        CSM. transform.localRotation = Quaternion.Euler(CSM.xrot, 0F, 0F);
        CSM.xrot = Mathf.Clamp(CSM.xrot, -90f, 90f);
        CSM.Body.Rotate(Vector3.up * joystickX);

    }
}