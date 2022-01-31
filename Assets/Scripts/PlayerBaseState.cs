using UnityEngine;

public abstract class PlayerBaseState 
{
    public abstract void EnterState(PlayerStateManager PSM);
    public abstract void UpdateState(PlayerStateManager PSM);
    public abstract void OnCollisionEnter(PlayerStateManager PSM, Collision collision);
}
