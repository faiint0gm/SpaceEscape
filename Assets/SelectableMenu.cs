using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class SelectableMenu : MonoBehaviour
{

    GameObject lastselect;
    //public Button startButton;
    //int minValue = 0, maxValue = 100, variationAmount = 2;
    //public Slider sliderRef;


    void Start()
    {
        lastselect = new GameObject();
        EventSystem.current.SetSelectedGameObject(EventSystem.current.firstSelectedGameObject);

        /*sliderRef = this.gameObject.GetComponent<Slider>();
        sliderRef.minValue = minValue;
        sliderRef.maxValue = maxValue;*/

    }

    void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == null)
        {
            EventSystem.current.SetSelectedGameObject(lastselect);
        }
        else
        {
            lastselect = EventSystem.current.currentSelectedGameObject;
        }

       /* if (Input.GetKeyDown("a"))
        {

            sliderRef.value -= variationAmount;
        }
        else if (Input.GetKeyDown("d"))
        {
            sliderRef.value += variationAmount;
        }*/


    }
}
