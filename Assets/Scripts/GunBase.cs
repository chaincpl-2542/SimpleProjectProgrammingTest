using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    #region GunValue
    private int basedamage;
    private int currentAmmo;
    private int baseMaxAmmo;
    private float baseFirerate;
    private float baseMaxRecoil;
    private float baseRecoilSpeed;
    private float baseRecoil;
    private bool canShoot;

    #endregion

    #region  Referrent
    public int damage;
    public float firerate;
    public float maxRecoil;
    public float recoilspeed;
    public float recoil;
    public int ammo;
    public int maxAmmo;

    #endregion

    #region Condition
    // Start is called before the first frame update
    void Start()
    {
        Innitialize();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCondition();
        CalculateFireRate();
        CalculateRecoil();
        ammo = currentAmmo;
        recoil = baseRecoil;
    }

    public virtual void Innitialize()
    {
        SetConfigData();
    }

    public virtual void SetConfigData()
    {  
        basedamage = damage;
        baseFirerate = firerate;
        baseRecoilSpeed = recoilspeed;
        baseMaxRecoil = maxRecoil;
        baseMaxAmmo = maxAmmo;
        currentAmmo = maxAmmo;
    }

    public virtual void UpdateCondition()
    {
       
    }

    public virtual void CalculateRecoil()
    {
        baseRecoil = Mathf.Lerp(baseRecoil, 0f, Time.deltaTime * recoilspeed * 1.2f);

        if(baseRecoil > baseMaxRecoil)
        {
            baseRecoil = baseMaxRecoil;
        }
    }

    public virtual void CalculateFireRate()
    {
        
        if(firerate > 0)
        {
            canShoot = false;
            firerate -= Time.deltaTime;
        }
        else
        {
            canShoot = true;
            firerate = 0;
        }
    }

    public virtual void Shoot()
    {
        if(currentAmmo > 0 && canShoot)
        {
            OnShoot();
        }
    }

    public virtual void OnShoot()
    {
        OnUseAmmo(); 
        firerate = baseFirerate;
        baseRecoil += baseRecoilSpeed;
    }

    public virtual void OnUseAmmo()
    {
        currentAmmo -= 1;
    }

    public virtual void Reload()
    {
        OnReload();
    }

    public virtual void OnReload()
    {
        currentAmmo = baseMaxAmmo;
    }
    #endregion
}
