using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    public float movementSpeed = 10f;

    private enum SpawnPoint {NORTH, SOUTH, EAST, WEST};
    private int Spawn;
    //private WaveSpawnScript wavespawnscript;
    //public GameObject SpawnSouth;
    //public GameObject SpawnWest;
    //public GameObject SpawnEast;
    //public GameObject SpawnNorth;

    private Transform target;
    private int waypointIndex = 0;
    //private Random rnd;

    //public int spawnIndex { get { return spawnIndex; } set { spawnIndex = value; } }

    //--------------------------------------------------------------------------------------------------------------------------------------------//
    //                                                                                                                                            //
    //                                                                     Start();                                                               //
    //                                                                                                                                            //
    //--------------------------------------------------------------------------------------------------------------------------------------------//

    #region Code Summary Start
    /// <summary>
    /// At first the target is the First waypoint in the waypoints list
    /// </summary>
    #endregion

    void Awake ()
    {
        //Debug.Log(transform.position);
        if (transform.position.x > 149 && transform.position.x < 151 && transform.position.z > 19 && transform.position.z < 21) // EAST
        {
            target = East.waypoints[0];
            //Debug.Log("EAST");
            Spawn = (int)SpawnPoint.EAST;
        }
        if (transform.position.x > 3 && transform.position.x < 6 && transform.position.z > 0 && transform.position.z < 1) // SOUTH
        {
            target = WaypointsScript.waypoints[0];
            //Debug.Log("SOUTH");
            Spawn = (int)SpawnPoint.SOUTH;
        }
        if (transform.position.x > 53 && transform.position.x < 56 && transform.position.z > 148 && transform.position.z < 151) // WEST
        {
            target = West.waypoints[0];
            //Debug.Log("WEST");
            Spawn = (int)SpawnPoint.WEST;
        }
        if (transform.position.x > 139 && transform.position.x < 141 && transform.position.z > 148 && transform.position.z < 151) // NORTH
        {
            target = North.waypoints[0];
            //Debug.Log("NORTH");
            Spawn = (int)SpawnPoint.NORTH;
        }
    }

    //--------------------------------------------------------------------------------------------------------------------------------------------//
    //                                                                                                                                            //
    //                                                                     Update();                                                              //
    //                                                                                                                                            //
    //--------------------------------------------------------------------------------------------------------------------------------------------//

    #region Code Summary Update
    /// <summary>
    /// Moves the enemy towards the current target which is a waypoint
    /// -----------
    /// if the enemy is within close proximity of the target waypoint... Call GetNextWaypoint()
    /// </summary>
    #endregion

    void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * movementSpeed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }

    //--------------------------------------------------------------------------------------------------------------------------------------------//
    //                                                                                                                                            //
    //                                                                     GetNextWaypoint();                                                     //
    //                                                                                                                                            //
    //--------------------------------------------------------------------------------------------------------------------------------------------//

    #region Code Summary GetNextWaypoint
    /// <summary>
    /// if the current waypoint is the last waypoint in the level... destroy the current iteration of enemy
    /// -----------
    /// TODO: decrement player lives when this happens
    /// -----------
    /// increment waypointindex and find a new target (The next index of the waypoints list)
    /// </summary>
    #endregion

    void GetNextWaypoint()
    {
        if (Spawn == (int)SpawnPoint.SOUTH)
        {
            if (waypointIndex >= WaypointsScript.waypoints.Length - 1)
            {
                Destroy(gameObject);
                return;
            }

            waypointIndex++;
            target = WaypointsScript.waypoints[waypointIndex];
        }
        if (Spawn == (int)SpawnPoint.EAST)
        {
            if (waypointIndex >= East.waypoints.Length - 1)
            {
                Destroy(gameObject);
                return;
            }

            waypointIndex++;
            target = East.waypoints[waypointIndex];
        }
        if (Spawn == (int)SpawnPoint.WEST)
        {
            if (waypointIndex >= West.waypoints.Length - 1)
            {
                Destroy(gameObject);
                return;
            }

            waypointIndex++;
            target = West.waypoints[waypointIndex];
        }
        if (Spawn == (int)SpawnPoint.NORTH)
        {
            if (waypointIndex >= North.waypoints.Length - 1)
            {
                Destroy(gameObject);
                return;
            }

            waypointIndex++;
            target = North.waypoints[waypointIndex];
        }
    }
}
