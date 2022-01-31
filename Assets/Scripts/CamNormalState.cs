using UnityEngine;
public class CamNormalState : CameraBaseState
{
    public override void EnterState(GyroCam CSM)
    {
        Debug.Log("Entering Nomral TPS State");
        CSM.isFPS = false;
        CSM.transform.SetParent(GameObject.Find("drone").transform);
        CSM.transform.position = GameObject.Find("drone").transform.position;
        CSM.transform.rotation = Quaternion.Euler(90f, -90f, 0F);

       // CSM.GetComponentInChildren<Renderer>().enabled = false;
        GameObject.Find("tps_turret").GetComponentInChildren<Renderer>().enabled = true;
        GameObject.Find("t_barrel").GetComponentInChildren<Renderer>().enabled = true;
    }

    public override void OnCollisionEnter(GyroCam PSM, Collision collision)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(GyroCam PSM)
    {
       
    }
}