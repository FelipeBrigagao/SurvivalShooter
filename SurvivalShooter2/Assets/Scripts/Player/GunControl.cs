using System.Collections;
using UnityEngine;

public class GunControl : MonoBehaviour
{
    #region Variables
    [Header("Gun References")]
    [SerializeField] private Transform firePoint;
    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] private GameObject enemyGetShotEffect;
    [SerializeField] private GameObject wallGetShotEffect;
    [SerializeField] private LineRenderer shootLine;
    private AudioSource gunSound;

    [Header("Gun Values")]
    [SerializeField] private int gunDamage = 10;
    [SerializeField] private float fireRate = .3f;
    [SerializeField] private float shotRange = 20f;
    private float nextTimeToShoot = 0;
    private Ray shotRay;

    [SerializeField] private LayerMask _hitableLayers; 

    public bool isShooting { get; private set; }

    private float shotLineFlashTime = .2f;
    #endregion


    #region Unity Methods
    private void Start()
    {
        gunSound = GetComponent<AudioSource>();
    }
    #endregion


    #region Methods

    public void Shoot()
    {

        isShooting = true;

        if(Time.time >= nextTimeToShoot && !PlayerManager.Instance.playerIsDead && !GameManager.Instance.gameIsPaused)
        {
            shotRay = new Ray(firePoint.position, firePoint.forward);

            nextTimeToShoot = Time.time + fireRate;

            muzzleFlash.Play();
            gunSound.Play();

            StartCoroutine(ShotLineInstantiate());
            shootLine.SetPosition(0, firePoint.position);

            if (Physics.Raycast(shotRay, out RaycastHit hitInfo, shotRange, _hitableLayers))
            {
                shootLine.SetPosition(1, hitInfo.point);

                if (hitInfo.transform.gameObject.CompareTag("Enemy"))
                {
                    HealthBase enemyHealth = hitInfo.transform.GetComponent<HealthBase>();
                    enemyHealth?.TakeDamage(gunDamage);

                    GameObject enemyShotEffect = Instantiate(enemyGetShotEffect, hitInfo.point, Quaternion.Euler(hitInfo.normal));
                    Destroy(enemyShotEffect, .5f);
                }
                else
                {
                    GameObject wallShotEffect = Instantiate(wallGetShotEffect, hitInfo.point, Quaternion.Euler(hitInfo.normal));
                    Destroy(wallShotEffect, .5f);
                }

            }
            else
            {
                shootLine.SetPosition(1, firePoint.position + firePoint.forward * shotRange);
            }
        }


    }

    public void StopShooting()
    {
        isShooting = false;
    }


    private IEnumerator ShotLineInstantiate()
    {
        shootLine.enabled = true;
        yield return new WaitForSeconds(fireRate * shotLineFlashTime); //pegando uma porcentagem do fire rate não vai acontecer de começar outra corroutine antes dessa acabar
        shootLine.enabled = false;
    }


    #endregion

}
