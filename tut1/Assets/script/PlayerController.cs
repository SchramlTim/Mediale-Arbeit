using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	private Rigidbody rb;
	private int score;
	public Text scoreText;
	public Text winText;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		score = 0;
		setScore ();
		winText.text="";
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
		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		// with drag
		//rb.AddForce (movement*speed);

		// without drag
		rb.velocity = new Vector3(moveHorizontal, 0.0f, moveVertical)*speed;
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
			gameObject.FindWithTag ("explosion").SetActive (true);
			if (score < 0) {
				winText.text="Fail!!";
			}
		}
	}
	void setScore(){
		scoreText.text = "Score: " + score.ToString ();
	}
}
