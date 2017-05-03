using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager BuildManagerInstance;

    private GameObject BuildThisTurret;
    public GameObject firstTurretPrefab;
    public GameObject missileTurretPrefab;
    public GameObject testTurretPrefab;

    //--------------------------------------------------------------------------------------------------------------------------------------------//
    //                                                                                                                                            //
    //                                                                     Awake();                                                               //
    //                                                                                                                                            //
    //--------------------------------------------------------------------------------------------------------------------------------------------//

    #region Code Summary Awake
    /// <summary>
    /// Awake is called before start. used to make sure that certain instances are instantiated before being used in Start()
    /// -----------
    /// Used to make sure there is only ONE instance of Buildmanager and sets the buildmanagerinstance to the current GameObject
    /// </summary>
    #endregion

    void Awake()
    {
        if (BuildManagerInstance != null)
        {
            Debug.LogError("More Than One BuildManagerInstance in this Scene");
            return;
        }
        BuildManagerInstance = this;
    }

    //--------------------------------------------------------------------------------------------------------------------------------------------//
    //                                                                                                                                            //
    //                                                                     Start();                                                               //
    //                                                                                                                                            //
    //--------------------------------------------------------------------------------------------------------------------------------------------//

    #region Code Summary Start
    /// <summary>
    /// Selected turret is the turret to build
    /// -----------
    /// TODO: be able to select different kind of turret prefabs
    /// </summary>
    #endregion

    void Start()
    {
        //BuildThisTurret = firstTurretPrefab;
    }

    //--------------------------------------------------------------------------------------------------------------------------------------------//
    //                                                                                                                                            //
    //                                                                     GetBuildThisTurret();                                                  //
    //                                                                                                                                            //
    //--------------------------------------------------------------------------------------------------------------------------------------------//

    #region Code Summary GetBuildThisTurret
    /// <summary>
    /// Gets the selected turret to build
    /// </summary>
    /// <returns>
    /// selected turret prefab
    /// </returns>
    #endregion

    public GameObject GetBuildThisTurret()
    {
        return BuildThisTurret;
    }


    //--------------------------------------------------------------------------------------------------------------------------------------------//
    //                                                                                                                                            //
    //                                                                     SetBuildThisTurret();                                                  //
    //                                                                                                                                            //
    //--------------------------------------------------------------------------------------------------------------------------------------------//
    public void SetBuildThisTurret(GameObject pTurret)
    {
        BuildThisTurret = pTurret;
    }

}
