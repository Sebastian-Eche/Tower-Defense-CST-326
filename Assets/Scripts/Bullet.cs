using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 70f;
    public float explosionRadius = 0f;
    public int damage = 50;
    public GameObject impactEffect;
    private Transform target;
    public void Seek(Transform _target)
    {
        target = _target;
    }
    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = bulletSpeed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

        transform.LookAt(target);

    }

    void HitTarget()
    {
        GameObject impactEffectIns = (GameObject)Instantiate(impactEffect, transform.position, Quaternion.identity);

        Destroy(impactEffectIns, 5f);

        if(explosionRadius > 0f)
        {
            Explode();
        }else{
            Damage(target);
        }

        Destroy(gameObject);
    }

    void Explode()
    {
        Collider[] hitObjects = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider collider in hitObjects)
        {
            if(collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
            
        }
    }

    void Damage (Transform enemy)
    {
        //MAYBE ADD DESTROY ENEMY DEPENDING ON HEALTH
        Enemy e = enemy.GetComponent<Enemy>();
        if(e != null)
        {
            e.TakeDamage(damage);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
