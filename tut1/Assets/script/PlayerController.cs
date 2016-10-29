using UnityEngine;
using UnityEngine.UI;
using System.Collections;

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
		// constant move forward;
		float moveVertical = 1f;

		// apply movement
		//Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		// with drag
		//rb.AddForce (movement*speed);

		// without drag
		//rb.velocity = new Vector3(moveHorizontal, 0.0f, moveVertical)*speed;

		// Mobile move
		transform.Translate(Input.acceleration.x, 0, moveVertical);
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
	}
	void setScore(){
		scoreText.text = "Score: " + score.ToString ();
	}
}
