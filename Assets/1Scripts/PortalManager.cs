using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    public Transform PosBlu;
    public Transform PosOrn;
    private Vector3 offset = new Vector3(0f, 0f, 0f);


    public void OnTriggerEnter(Collider col)
    {
        if (PosBlu.transform.position.y > -100f && PosOrn.transform.position.y > -100f)
          {
            if (col.CompareTag("Portal Blue"))
            {
                CharacterController c = GetComponent<CharacterController>();
                c.enabled = false;
                //position
                offset = PosOrn.forward * 1.5f;
                transform.position = PosOrn.transform.position + offset;
                //rotation
                //float angDiffPortals = Quaternion.Angle(PosBlu.rotation, PosOrn.rotation);
                //Quaternion portalRotationDiff = Quaternion.AngleAxis(angDiffPortals, transform.up);
                transform.rotation = Quaternion.LookRotation(PosOrn.forward);
                c.enabled = true;

            }
            if (col.CompareTag("Portal Orange"))
            {
                CharacterController c = GetComponent<CharacterController>();
                c.enabled = false;
                offset = PosBlu.forward * 1.5f;
                //position
                transform.position = PosBlu.transform.position + offset;
                //rotation
                transform.rotation = Quaternion.LookRotation(PosBlu.forward);
                c.enabled = true;
            }
          }
    }
    
}
