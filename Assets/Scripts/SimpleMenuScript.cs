using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SimpleMenuScript : MonoBehaviour
{
    public void ExitGame (){
        Application.Quit();
    }

    public void StartGame (string sceneToLoad){
        SceneManager.LoadScene( sceneToLoad );
    }
}
