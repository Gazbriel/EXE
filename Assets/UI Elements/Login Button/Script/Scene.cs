using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Scene
{
    public string sceneName;
    public string username;
    public string password;

    //Do the Log in check and change scene
    public void Login(string inputName, string inputPasssword)
    {
        //if the username and password inputs are correct
        if (MatchUsername(inputName) && MatchPassword(inputPasssword))
        {
            //Log in this scene
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.Log("Wrong user or password for scene: " + sceneName);
        }
    }

    public bool MatchUsername(string inputName)
    {
        //if the name match, return true, else, return false
        return (inputName == username) ? true : false;
    }
    public bool MatchPassword(string inputPasssword)
    {
        return (inputPasssword == password) ? true : false;
    }
}


