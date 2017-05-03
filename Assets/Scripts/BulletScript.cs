using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    private Transform target;
    public float bulletSpeed = 65f;

    //--------------------------------------------------------------------------------------------------------------------------------------------//
    //                                                                                                                                            //
    //                                                                     Seek();                                                                //
    //                                                                                                                                            //
    //--------------------------------------------------------------------------------------------------------------------------------------------//

    #region Code Summary Seek
    /// <summary>
    /// Called when bullet is instantiated in turretScript
    /// -----------
    /// sets target to the currently iterated enemy
    /// </summary>
    /// <param name="_target">
    /// _target is the currently iterated enemy which is selected in TurretScript
    /// </param>
    #endregion

    public void Seek(Transform _target)
    {
        target = _target;
    }

    //--------------------------------------------------------------------------------------------------------------------------------------------//
    //                                                                                                                                            //
    //                                                                     Update();                                                              //
    //                                                                                                                                            //
    //--------------------------------------------------------------------------------------------------------------------------------------------//

    #region Code Summary Update
    /// <summary>
    /// If the bullet does NOT have a target it destroys itself
    /// -----------
    /// Moves toward the current target with a bullet speed in world space
    /// -----------
    /// if the distance between the bullet and the enemy is lower than the Delta Magnitude. Call HitTarget() and return out of this function
    /// </summary>
    #endregion

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = target.position - transform.position;
        float currentDistance = bulletSpeed * Time.deltaTime;

        if (direction.magnitude <= currentDistance)
        {
            HitTarget();
            DamageTarget(target);
            return;
        }

        transform.Translate(direction.normalized * currentDistance, Space.World);
    }

    //--------------------------------------------------------------------------------------------------------------------------------------------//
    //                                                                                                                                            //
    //                                                                     HitTarget();                                                           //
    //                                                                                                                                            //
    //--------------------------------------------------------------------------------------------------------------------------------------------//

    #region Code Summary HitTarget
    /// <summary>
    /// Called when bullet hits its target
    /// -----------
    /// Destroys the bullet GameObject
    /// -----------
    /// TODO: Destroy &| Damage the enemy
    /// </summary>
    #endregion

    void HitTarget()
    {
        Destroy(gameObject);
    }

    void DamageTarget(Transform enemy)
    {
        Destroy(enemy.gameObject);
    }
}
