using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MainMenuManager : MonoBehaviour
{



    public void LoadScene()
    {
        SceneManager.LoadScene("LevelOne");
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            SceneManager.LoadScene("LevelOne");
        }
    }

}
