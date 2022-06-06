using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
	{
		ResetGame();
	}

    public void ResetGame(){
         SceneManager.LoadScene("SampleScene");
        
    }
}
