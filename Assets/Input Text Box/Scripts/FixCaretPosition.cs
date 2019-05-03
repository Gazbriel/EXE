using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixCaretPosition : MonoBehaviour
{
    //-----------------------------------------------------
    //THIS SCRIPT MUST BE ON THE TEXT ON THE INPUT FIELD
    //-----------------------------------------------------
    private string caretGameObjectName;
    public GameObject caret;
    // Start is called before the first frame update
    void Start()
    {
        caretGameObjectName = transform.parent.name;
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        
        CheckCaret();
        
    }

    private bool fixedCaret = false;
    private void CheckCaret()
    {
        //if caret is not fixed yet
        if (!fixedCaret)
        {
            //search for caret and try to fix it
            try
            {
                caret = GameObject.Find(caretGameObjectName + " Input Caret");

                Debug.Log("Caret found");
            }
            catch (System.Exception)
            {
                Debug.Log("Caret not found");
                throw;
            }

            //if caret was found
            if (caret != null)
            {
                Vector3 caretPosition = caret.GetComponent<RectTransform>().localPosition;
                caret.GetComponent<RectTransform>().localPosition = new Vector3(Mathf.Round(caretPosition.x), Mathf.Round(caretPosition.y - 1), caretPosition.z);
                
                //caret.GetComponent<RectTransform>().position.y;
                Debug.Log(caret.GetComponent<RectTransform>().localPosition.y);
                //caret dont need to be fixed anymore
                fixedCaret = true;
                Debug.Log("Fixed Caret");
            }
        }
    }
}
