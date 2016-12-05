using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class sceneController : MonoBehaviour {
	public Object lvl1;
	public Object lvl2;
	public Object lvl3;
	//used in levels
	public void returnToHub(){
		SceneManager.LoadScene("Hub");
	}
	public void restartGame(){
		Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
	}


	// hubworld
	public void loadLvl1(){
		SceneManager.LoadScene(lvl1.name);//("prototype");
		Debug.Log("TEEEEEEEEEEEEEEEEEEEEEEEEEEST:" + lvl1.name);
	}
	public void loadLvl2(){
		SceneManager.LoadScene(lvl2.name);
		//SceneManager.LoadScene("Lvl screens");
	}
	public void loadLvl3(){
		SceneManager.LoadScene(lvl3.name);
		//Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
	}
}
