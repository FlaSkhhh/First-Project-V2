using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Gun : MonoBehaviour
{
  public Camera fpsCam;
  public float damage = 5f;
  public float range = 100f;
  public float fireRate = 15f;
  public ParticleSystem muzzleFlash;
  public GameObject impactEff;
  public AudioManager sound;
  public LayerMask hitLayers;
  private float nextFire = 0f;

  void Update()
  {
    if(Input.GetButtonDown("Fire1") && Time.time >= nextFire)
    {
      nextFire = Time.time + 1 / fireRate;
      Shoot();
    }

    void Shoot()
    {
      muzzleFlash.Play();
      sound.Play("GunShot");
      RaycastHit hit;
      if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range, hitLayers))
      {
        //Target target = hit.transform.GetComponent<Target>();
        //if(target != null)
        //{
        //  sound.Play("GunShotHit");
        //  target.TakeDamage(damage);
        //}
        BossTarget btarget = hit.transform.GetComponent<BossTarget>();
         if (btarget != null && btarget.enabled==true)
         {
           sound.Play("GunShotHit");
           btarget.TakeDamage(damage);
         }
        sound.Play("GunShotHit");
        GameObject impactGO = Instantiate(impactEff, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impactGO, 2f);
      }
    }
  }
}
