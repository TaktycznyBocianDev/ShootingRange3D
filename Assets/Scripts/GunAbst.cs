using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GunAbst : MonoBehaviour
{

    //Common Fields
    [Header("Fields common for every weapon")]
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 50f;
    public float impactForce = 60f;
    public float maxAmmo = 1f;
    public float reloadTime = 0.9f;
    public bool isAutomatic = true;
    public string animationVariable;
    public string animationName;

    [Header("Needed componenets")]
    public Camera playerCam;
    public AudioClip shootSound, reloadSound;


    protected Animator weaponAnimator;
    protected AudioSource weaponAudioSource;
    protected float nextTimeToFire = 0f;
    protected float currentAmmo = 0f;
    protected bool isReloading = false;
    protected bool hasReloadAnimationStop = false;

    private void Start()
    {
        currentAmmo = maxAmmo;
    }

    protected virtual void Update()
    {

        if (isReloading) return; //stop everything else if PLayer is reloading

        if (currentAmmo <= 0 || (Input.GetKeyDown(KeyCode.R) && currentAmmo != maxAmmo))
        {
            StartCoroutine(Reload());
            return;
        }

        if (isAutomatic)
        {
            if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1f / fireRate;
                Shoot();
            }
        }
        else
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }

    }

    protected virtual void Shoot()
    {

        //weaponAudioSource.clip = shootSound;
        weaponAudioSource.PlayOneShot(shootSound);

        RaycastHit hit;

        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, range))
        {
            //Debug.Log(hit.transform.name);
            //EnemyBehaviour target = hit.transform.GetComponent<EnemyBehaviour>();
            //if (target != null)
           // {
            //    target.TakeDamage(damage, impactForce, hit);
           // }
        }



        currentAmmo--;

    }

    protected virtual IEnumerator Reload()
    {
        isReloading = true;
        

        weaponAnimator.SetBool(animationVariable, true);
        

        weaponAudioSource.clip = reloadSound;
        weaponAudioSource.Play();

        yield return new WaitUntil(() => isAnimationPlaying);

        weaponAnimator.SetBool(animationVariable, false);
        currentAmmo = maxAmmo;
        isReloading = false;
    }

    protected virtual void ReloadAnimationIsOn()
    {
        AnimatorStateInfo stateInfo = weaponAnimator.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.IsName(animationName) && stateInfo.normalizedTime < 1.0f)
        {
            isAnimationPlaying = true;
        }
        else
        {
            isAnimationff = false;
        }
    }
}
