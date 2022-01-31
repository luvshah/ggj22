using UnityEngine;
public abstract class CameraBaseState
{
    public abstract void EnterState(GyroCam CSM);
    public abstract void UpdateState(GyroCam PSM);
    public abstract void OnCollisionEnter(GyroCam PSM, Collision collision);
}