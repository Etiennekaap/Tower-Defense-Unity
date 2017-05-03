using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.BuildManagerInstance;
    }

    public void BuyNoTurret()
    {
        buildManager.SetBuildThisTurret(null);
    }

	public void BuyBasicTurret()
    {
        buildManager.SetBuildThisTurret(buildManager.firstTurretPrefab);
    }

    public void BuyMissileTurret()
    {
        buildManager.SetBuildThisTurret(buildManager.missileTurretPrefab);
    }

    public void BuySwagTurret()
    {
        buildManager.SetBuildThisTurret(buildManager.testTurretPrefab);
    }
}
