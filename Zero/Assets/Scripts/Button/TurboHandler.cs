using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[System.Serializable]
public class TurboHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

    [Header("Fuel Info")]
    public Image fuel_image;

    private Player playerScript;
    bool _pressed = false;
    int count;

    private FuelHandler fuelHandler;
    private float fuelSpeedConsumption;
    private float fuelSpeedRecharge;

    void Awake()
    {
        count = 0;
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        fuelHandler = fuel_image.GetComponent<FuelHandler>();
        fuelSpeedConsumption = playerScript.GetFuelSpeedConsumption();
        fuelSpeedRecharge = playerScript.GetFuelSpeedRecharge();
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        _pressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _pressed = false;
    }

    void Update()
    {
        if (_pressed)
        {

            if (count == 0)
            {
                playerScript.ModifySpeed(1);
                count += 1;
            }
            fuelHandler.ConsumeFuel(fuelSpeedConsumption * Time.deltaTime);
            if (fuelHandler.GetCurrentFuel() == 0 && count == 1)
            {
                playerScript.ModifySpeed(-1);
                count -= 1;
            }
        }

        if(!_pressed)
        {
            if (count == 1)
            {
                playerScript.ModifySpeed(-1);
                count -= 1;
            }
            fuelHandler.RestoreFuel(fuelSpeedRecharge * Time.deltaTime); //We have another update in player with the same line, this is the only one needed on release on smartphone
        }


    }
	
}
