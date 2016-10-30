using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class sceneController : MonoBehaviour {
	//used in levels
	public void returnToHub(){
		SceneManager.LoadScene("Hub");
	}
	public void restartGame(){
		Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
	}


	// hubworld
	public void loadLvl1(){
		SceneManager.LoadScene("prototype");
	}
	public void loadLvl2(){
		SceneManager.LoadScene("Lvl screens");
	}
	public void loadLvl3(){
		Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
	}
}
