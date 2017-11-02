using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[System.Serializable]
public class TurboHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

    private Player playerScript;
    bool _pressed = false;
    int count;

    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
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
        if (_pressed && count == 0)
        {
            playerScript.ModifySpeed(1);
            count += 1;
        }

        if(!_pressed && count == 1)
        {
            playerScript.ModifySpeed(-1);
            count -= 1;
        }


    }
	
}
