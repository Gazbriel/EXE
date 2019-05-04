using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LoginButtonAction : MonoBehaviour
{

    public InputField user;
    public InputField password;

    public Text outputTest;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Enter pressed");
            Login();
        }
    }

    public GameObject userAlert;
    public GameObject passwordAlert;
    public Scene[] scenes;
    
    public void Login()
    {
        //get the user and password strings and output it jus for testing
        Debug.Log("User " + user.text + " Pass: " + password.text);
        outputTest.text = "User: " + user.text + " Pass: " + password.text;

        //this values determines if there is any user or password that match the inpuit fields
        bool foundUsername = false;
        bool foundPassword = false;

        //Testing changing the Scene
        foreach (var scene in scenes)
        {
            //check for matches for later pop up the alert notification
            foundUsername = scene.MatchUsername(user.text);
            foundPassword = scene.MatchPassword(password.text);

            //load the scene if some user and pass matched
            scene.Login(user.text, password.text);
        }

        //if user and password are wrong, tell wich one or if both are wrong
        //do this by enableing the game object Alert
        userAlert.SetActive(!foundUsername);
        passwordAlert.SetActive(!foundPassword);

        //Deselect the Button after clicking on it
        EventSystem.current.SetSelectedGameObject(null);
    }
}
