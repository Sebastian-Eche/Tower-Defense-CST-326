using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;
    private Enemy targetEnemy;

    [Header("General Attributes")]
    public float range = 15f;
    public float turnSpeed = 10f;

    [Header("User Bullets (default)")]
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("Use Laser")]
    public bool useLaser = false;
    public int damageOverTime = 30;
    public LineRenderer lineRenderer;
    public ParticleSystem laserImpactEffect;
    public Light impactLight;
    public float slowPercent = 0.3f;

    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";
    public Transform partToRotate;
    public Transform spawnBullet;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = (transform.position - enemy.transform.position).magnitude;
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }else{
            target = null;
            targetEnemy = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null){
            if(useLaser){
                if(lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                    laserImpactEffect.Stop();
                    impactLight.enabled = false;
                }
            }
            return;
        }

        LockOnTarget();

        if(useLaser)
        {
            Laser();
        }else
        {
            if(fireCountdown <= 0)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;

        }
    }

    void Shoot()
    {
        GameObject bulletGO = Instantiate(bulletPrefab, spawnBullet.position, Quaternion.identity, gameObject.transform);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if(bullet != null)
        {
            bullet.Seek(target);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);   
    }

    void LockOnTarget()
    {
        //HOW TO MAKE TURRET FOLLOW TARGET (TARGET LOCK ON)
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 finalRotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, finalRotation.y, 0f);
    }

    void Laser()
    {
        targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
        targetEnemy.Slow(slowPercent);
        if(!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            laserImpactEffect.Play();
            impactLight.enabled = true;
        }
        lineRenderer.SetPosition(0, spawnBullet.position);
        lineRenderer.SetPosition(1, target.position);

        Vector3 dir = spawnBullet.position - target.position;

        laserImpactEffect.transform.position = target.position + dir.normalized;

        laserImpactEffect.transform.rotation = Quaternion.LookRotation(dir);
    }

    
}
