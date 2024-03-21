using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 70f;
    public GameObject impactEffect;
    private Transform target;
    public void Seek(Transform _target)
    {
        target = _target;
    }
    // Start is called before the first frame update
    void Start()
    {
        
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

    }

    void HitTarget()
    {
        GameObject impactEffectIns = (GameObject)Instantiate(impactEffect, transform.position, Quaternion.identity);

        Destroy(impactEffectIns, 2f);

        //MAYBE ADD DESTROY ENEMY DEPENDING ON HEALTH
        Destroy(target.gameObject);
        Destroy(gameObject);
    }
}
