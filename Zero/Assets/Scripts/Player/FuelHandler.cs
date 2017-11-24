using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelHandler : MonoBehaviour {

    public Image fuel_bar;
    private Color start_color;
    private float maxfuel = 100;
    private float currentfuel = 100;

	private void Awake()
    {
        start_color = fuel_bar.color;
    }
	
	private void UpdateFuelBar () {
        float ratio = currentfuel / maxfuel;
        fuel_bar.rectTransform.localScale = new Vector3(ratio, 1, 1);
        fuel_bar.color = Color.Lerp(start_color, Color.red, 1 - ratio);
	}

    public void ConsumeFuel(float value)
    {
        currentfuel -= value;
        if (currentfuel < 0)
            currentfuel = 0;
        UpdateFuelBar();
    }

    public void RestoreFuel(float value)
    {
        currentfuel += value;
        if (currentfuel > maxfuel)
            currentfuel = maxfuel;
        UpdateFuelBar();
    }

    public float GetCurrentFuel()
    {
        return currentfuel;
    }
}
