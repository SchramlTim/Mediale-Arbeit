using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class buttonController : MonoBehaviour {

	public void quitGame(){
		Application.Quit ();
	}
	public void restartGame(){
		Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
	}
}
