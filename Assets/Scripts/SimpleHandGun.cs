using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SimpleHandGun : GunBase
{private GameObject baseBulletPrefab;
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
        if(Input.GetMouseButtonDown(0))
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
            Instantiate(muzzlePrefab,baseBulletPoint.position,baseBulletPoint.rotation);

            GameObject _bullet = Instantiate(baseBulletPrefab,baseBulletPoint.position,baseBulletPoint.rotation);
            _bullet.GetComponent<Rigidbody>().AddForce(transform.forward * baseBulletSpeed);
            Destroy(_bullet,3);
        }
        float currentRecoilX = Random.Range(-recoil, recoil);
        float currentRecoilY = Random.Range(-recoil, recoil);
        
        baseBulletPoint.localEulerAngles = new Vector3(initialRotation.x + currentRecoilX,initialRotation.y + currentRecoilY,initialRotation.z);
    }
}
