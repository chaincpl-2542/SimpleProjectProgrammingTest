using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRifleGun : GunBase
{
    private GameObject baseBulletPrefab;
    private GameObject baseMuzzlePrefab;
    private Transform baseBulletPoint;
    private float baseBulletSpeed;
    private Vector3 initialRotation;

    public GameObject bulletPrefab;
    public GameObject muzzlePrefab;
    public Transform bulletPoint;
    public float bulletSpeed;

    public override void Innitialize()
    {
        base.Innitialize();

        initialRotation = baseBulletPoint.localEulerAngles;
    }
    public override void SetConfigData()
    {
        base.SetConfigData();
        baseBulletPrefab = bulletPrefab;
        baseMuzzlePrefab = muzzlePrefab;
        baseBulletPoint = bulletPoint;
        baseBulletSpeed = bulletSpeed;
    }

     public override void UpdateCondition()
    {
        base.UpdateCondition();
        if(Input.GetMouseButton(0))
        {
            Shoot();
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

    public override void CalculateRecoil()
    {
        base.CalculateRecoil();
        
    }

    public override void OnShoot()
    {
        base.OnShoot();
        if(baseBulletPrefab)
        {
            float currentRecoilX = Random.Range(-recoil, recoil);
            float currentRecoilY = Random.Range(-recoil, recoil);

            baseBulletPoint.transform.localEulerAngles = new Vector3(initialRotation.x + currentRecoilX,initialRotation.y + currentRecoilY,initialRotation.z);

            Instantiate(muzzlePrefab,baseBulletPoint.position,baseBulletPoint.rotation);

            GameObject _bullet = Instantiate(baseBulletPrefab,baseBulletPoint.position,baseBulletPoint.rotation);
            _bullet.GetComponent<Rigidbody>().AddForce(transform.forward * baseBulletSpeed);
            Destroy(_bullet,3);
        } 
    }
}
