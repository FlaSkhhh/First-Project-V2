using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTp : MonoBehaviour
{
    public Vector3 vector;
    public void ChangePos()
    {
      transform.position = vector;
        
    }
}
