using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

	public string sceneToChange;

	private void OnCollisionEnter2D (Collision2D collision)
    {
    	SceneManager.LoadScene(sceneToChange);
    	Debug.Log("into the farm!");
    }

}
