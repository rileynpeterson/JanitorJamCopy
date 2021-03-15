using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class GameHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start()
    {
 
    }

    // Update is called once per frame
    public void Update()
    {

    }
	
   
	public void QuitGame(){
		#if UNITY_EDITOR 
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}


    public void PlayGame()
    {
        SceneManager.LoadScene ("Level1");

    }
	
	
}
