using System.Collections;
using UnityEngine;

public class GunControl : MonoBehaviour
{
    [SerializeField] Transform firePoint;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject enemyGetShotEffect;
    [SerializeField] GameObject wallGetShotEffect;
    [SerializeField] LineRenderer shootLine;
    AudioSource gunSound;

    int gunDamage = 10;
    float fireRate = .3f;
    float nextTimeToShoot = 0;

    float shotRange = 20f;
    Ray shotRay;

    bool isShooting = false;
    bool playerDead = false;

    float shotLineFlashTime = .2f;

    // Start is called before the first frame update
    void Start()
    {
        gunSound = GetComponent<AudioSource>();
        PlayerStats.OnPlayerDeath += PlayerDied;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToShoot && !playerDead && !PauseMenu.gameIsPaused)
        {
            Shoot();

        }


    }

    void Shoot()
    {
        shotRay = new Ray(firePoint.position, firePoint.forward);

        nextTimeToShoot = Time.time + fireRate;

        muzzleFlash.Play();
        gunSound.Play();

        StartCoroutine(ShotLineInstantiate());
        shootLine.SetPosition(0, firePoint.position);

        if (Physics.Raycast(shotRay, out RaycastHit hitInfo, shotRange))
        {

            shootLine.SetPosition(1, hitInfo.point);
                
            if (hitInfo.transform.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                hitInfo.transform.GetComponent<EnemyStats>().TakeDamage(gunDamage);
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

    IEnumerator ShotLineInstantiate()
    {
        shootLine.enabled = true;
        yield return new WaitForSeconds(fireRate * shotLineFlashTime); //pegando uma porcentagem do fire rate não vai acontecer de começar outra corroutine antes dessa acabar
        shootLine.enabled = false;
    }


    void PlayerDied()
    {
        playerDead = true;
    }


    private void OnDestroy()
    {
        PlayerStats.OnPlayerDeath -= PlayerDied;
    }



    /*private void OnDrawGizmos()
    {
        Gizmos.DrawLine(firePoint.position, firePoint.forward * shotRange);
    }
    */

}
