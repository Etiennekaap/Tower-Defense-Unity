using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class North : MonoBehaviour {
    public static Transform[] waypoints;

    //--------------------------------------------------------------------------------------------------------------------------------------------//
    //                                                                                                                                            //
    //                                                                     Awake();                                                               //
    //                                                                                                                                            //
    //--------------------------------------------------------------------------------------------------------------------------------------------//

    #region Code Summary Awake
    /// <summary>
    /// Awake is called before start. used to make sure that certain instances are instantiated before being used in Start()
    /// -----------
    /// Checks the amount of children in the Waypoints object and adds the waypoints to the list
    /// </summary>
    #endregion

    void Awake()
    {
        waypoints = new Transform[transform.childCount];
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = transform.GetChild(i);
        }
    }
}