using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelPickUp : PickUp {
    
    [Header("Restored Fuel Value")]
    public float value;

    private GameObject playerObject;

    private FuelHandler fuelHandler;

    private void Start()
    {
        fuelHandler = GameObject.FindGameObjectWithTag("Player").GetComponent<FuelHandler>();
    }

    public override void ActivateEffect()
    {
        fuelHandler.RestoreFuel(value);
    }
}
