using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileTurretScript : TurretScript
{

    //private Transform target;
    //private float newTargetingTimer = 0.7f;

    //[Header("Turret Attributes")]
    //[SerializeField]
    //private float turretRange = 35f;
    //[SerializeField]
    //private float fireRate = 4f;
    //[SerializeField]
    //private float currentFireCooldown = 1f;

    //[Header("Unity Required Fields")]
    //[SerializeField]
    //private Transform PivotPoint;
    //[SerializeField]
    //private float rotationSpeed = 8f;
    //[SerializeField]
    //private string enemyTag = "Enemy";

    //[SerializeField]
    //private GameObject bulletPrefab;
    //[SerializeField]
    //private Transform firePoint;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, newTargetingTimer);
    }

    void UpdateTarget()
    {
        SeekTarget();
    }

    void Update()
    {
        if (target == null)
        {
            return;
        }

        Debug.Log(transform.position);


        Vector3 direction = target.position - transform.position;
        Quaternion lookAtRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(PivotPoint.rotation, lookAtRotation, Time.deltaTime * rotationSpeed).eulerAngles;
        PivotPoint.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (currentFireCooldown <= 0f)
        {
            ShootProjectile();
            currentFireCooldown = 1f / fireRate;
        }

        currentFireCooldown -= Time.deltaTime;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, turretRange);
    }
}
