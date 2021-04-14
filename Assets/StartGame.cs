using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    { /*
        if (Input.GetButtonDown("Start"))
        {
            SceneManager.LoadScene("_Scene_0");
        } */
    }
    public void PressButton()
    {
        SceneManager.LoadScene("_Scene_0");
    }
}
