using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PortalGun : MonoBehaviour
{
    public Camera fpsCam;
    public LayerMask hitLayers;
    public float fireRate = 50f;
    public float range = 10f;
    private float nextFire = 0f;
    public Transform PorBlu;
    public Transform PorOrn;
    public AudioManager sound;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextFire)
        {
            sound.Play("GunShotHit");
            nextFire = Time.time + 1 / fireRate;
            ShootBlu();
        }

        if (Input.GetButtonDown("Fire2") && Time.time >= nextFire)
        {
            sound.Play("GunShotHit");
            nextFire = Time.time + 1 / fireRate;
            ShootOrn();
        }

        void ShootBlu()
        {
            RaycastHit hit;
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range, hitLayers))
            {
                if (hit.collider != null)
                {
                    if (hit.collider.tag != "Portal Orange" && hit.collider.tag != "Portal Blue")
                    {
                        Transform target = PorBlu.GetComponent<Transform>();
                        target.transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);

                        var portalForward = hit.normal;
                        target.transform.rotation = Quaternion.LookRotation(portalForward);
                    }
                }
            }
        }

        void ShootOrn()
        {
            RaycastHit hit;
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range, hitLayers))
            {
                if (hit.collider != null)
                {
                    if (hit.collider.tag != "Portal Blue" && hit.collider.tag != "Portal Orange")
                    {
                        Transform target = PorOrn.GetComponent<Transform>();
                        target.transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                        var portalForward = hit.normal;

                        target.transform.rotation = Quaternion.LookRotation(portalForward);
                    }
                }
            }
        }
    }
}
