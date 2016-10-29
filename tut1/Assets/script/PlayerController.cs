using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour {

	public float speed;
	private Rigidbody rb;
	private int score;
	public Text scoreText;
	public Text winText;
	private ParticleSystem explosion;
	private GameObject explosionContainer;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		score = 0;
		setScore ();
		winText.text="";
		explosion = this.gameObject.transform.GetChild(0).GetChild(0).gameObject.GetComponent<ParticleSystem>();
		explosionContainer = GameObject.Find ("explosionContainer");
		explosionContainer.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void FixedUpdate(){
		// grab movement
		float moveHorizontal = Input.GetAxis ("Horizontal")*2f;
		//float moveVertical = Input.GetAxis("Vertical");
		// constantly move forward;
		float moveVertical = 1f;

		/*****************************
		 * Keyboard Movement
		 * ***************************/
		// apply movement with drag
		//Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		//rb.AddForce (movement*speed);
		// without drag
		//rb.velocity = new Vector3(moveHorizontal, 0.0f, moveVertical)*speed;

		/*****************************
		 * Mobile gyro Movement
		 * ***************************/
		transform.Translate(Input.acceleration.x*2.5f, 0, moveVertical);
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("item")) {
			other.gameObject.SetActive (false);
			score++;
			setScore ();
			if (score >= 7) {
				winText.text="Congratulations!!";
			}
		}
		if (other.gameObject.CompareTag ("obstacle")) {
			score--;
			setScore ();
			//explosion.SetActive (true);
			explosionContainer.SetActive (true);
			explosion.Stop();
			explosion.Play();
			if (score < 0) {
				winText.text="Fail!!";
				// Gameoverscreen.SetActive (true);
			}
		}
		if (other.gameObject.CompareTag ("finish")) {
			//Time.timeScale = 0;
			Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
			winText.text="FINISHLINE!!";
		}
	}
	void setScore(){
		scoreText.text = "Score: " + score.ToString ();
	}
}
