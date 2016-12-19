using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;




public class PlayerController : MonoBehaviour {

	public float speedVertical;
	private Rigidbody rb;
	private double score;
    private float highscore;
	public Text scoreText;
	public Text statusText;
	public Text winText;
    public Text highscoreText;
	private ParticleSystem explosion;
	private GameObject explosionContainer;
	private GameObject btnContainer;
	public float moveVertical = 1f;
	public float speedHorizontal = 1f;
	public float unlock = 2000f;
	public FuelController fuelCont;
	public AudioClip deathSound;
	public AudioClip endSound;
	public AudioClip fuelPickSound;
	public AudioClip coinSound;
	public AudioClip ingameSound;
	public GameObject MapGenerator;
	private AudioSource effectSound;
	private int inv = 1;
	float moveHorizontal;
	public float gyroSensitivity = 2.5f;


	// Use this for initialization
	void Start () {
		effectSound = GetComponent<AudioSource> ();
		rb = GetComponent<Rigidbody>();
		fuelCont = GetComponent<FuelController>();
		score = 0;
        highscore = 0;
        //highscoreText.text = "Highscore: " + PlayerPrefs.GetFloat("Highscore");
        setScore ();
		winText.text="";
		scoreText.text = "KM: 0";
		statusText.text = "All OK";
		explosion = this.gameObject.transform.GetChild(0).GetChild(0).gameObject.GetComponent<ParticleSystem>();
		explosionContainer = GameObject.Find ("explosionContainer");
		explosionContainer.SetActive (false);
		btnContainer = GameObject.Find ("Buttons");
		btnContainer.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
      if (highscore < score)
        {
            highscore = (float) score;
            PlayerPrefs.SetFloat("Highscore", highscore);
        }
        calcScore ();
    }
	void FixedUpdate(){
		/*****************************
		 * Keyboard Movement
		 * ***************************/
		// apply movement with drag
		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement*speedHorizontal);
		// grab movement
		moveHorizontal = (Input.GetAxis ("Horizontal") * 2f * inv * speedHorizontal);
		// without drag
		rb.velocity = new Vector3 (moveHorizontal, 0.0f, moveVertical) * speedVertical;

		/*****************************
		 * Mobile gyro Movement
		 * ***************************/
		//moveHorizontal = Input.acceleration.x * gyroSensitivity;
		//transform.Translate(moveHorizontal * inv, 0, moveVertical);
		calcScore ();
	}

	void OnTriggerEnter(Collider other)	{
		Debug.Log (other.gameObject.tag);
		if (other.gameObject.CompareTag ("fuel")) {
			other.gameObject.SetActive (false);
			setScore ();
            fuelCont.incFuel ();
			score++;
			MapGenerator.GetComponent<EndlessTerrain> ().resetLevel ();
			effectSound.PlayOneShot (fuelPickSound);
		}
		if (other.gameObject.CompareTag ("obstacle")) {
			setScore ();
            //fuelCont.decFuel ();
			explosionContainer.SetActive (true);
			explosion.Stop();
			explosion.Play();
			score--;
			if (score < 0) {
				winText.text="Fail!!";
			}
			effectSound.PlayOneShot (deathSound);
			stopMove ();
		}
		if (other.gameObject.CompareTag ("finish")) {
			//Time.timeScale = 0;
			btnContainer.SetActive (true);
			winText.text="FINISHLINE!!";
		}
		if (other.gameObject.CompareTag ("inverse")) {
			inv = inv * (-1);
			if (inv != 1) {
				statusText.text = "Inverse!";
			} else {
				statusText.text = "All OK!";
			}
			other.gameObject.SetActive (false);
		}
	}

	void calcScore(){
		score = System.Math.Round(transform.position.z, 2);
		setScore ();
        if (score >= unlock) {
			//winText.text="Congratulations unlocked new area!!";
		}
	}

	void setScore(){
		scoreText.text = "KM: " + score.ToString ();
	}

	public void stopMove(){
		speedVertical = 0f;
		speedHorizontal = 0f;
		winText.text="No Fuel!!";
		btnContainer.SetActive (true);
	}
}
