using UnityEngine;
public class CamDisabledState : CameraBaseState
{
    public override void EnterState(GyroCam CSM)
    {
        throw new System.NotImplementedException();
    }

    public override void OnCollisionEnter(GyroCam PSM, Collision collision)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(GyroCam PSM)
    {
        throw new System.NotImplementedException();
    }
}