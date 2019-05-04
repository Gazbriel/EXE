using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputNavigation : MonoBehaviour
{
    EventSystem system;

    //if true, the scene start with the first element selected.
    public bool startOnSelected;
    public GameObject startSelectedObject;
    void Start()
    {
        system = EventSystem.current;// EventSystemManager.currentSystem;

        //get the default start on selected object and select it
        if (startOnSelected)
        {
            system.SetSelectedGameObject(startSelectedObject);
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            //if nothing is selected, start selecting the default first selected object
            if (system.currentSelectedGameObject == null)
            {
                system.SetSelectedGameObject(startSelectedObject);
                //dont do the rest of the method, no NEXT on the selected object
                return;
            }

            //if something is selected and you pressed Tab then go to next object (down) on navigation
            Selectable next = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown();

            if (next != null)
            {

                InputField inputfield = next.GetComponent<InputField>();
                if (inputfield != null)
                    inputfield.OnPointerClick(new PointerEventData(system));  //if it's an input field, also set the text caret

                system.SetSelectedGameObject(next.gameObject, new BaseEventData(system));
            }

            

            //else Debug.Log("next nagivation element not found");

        }
    }
}
