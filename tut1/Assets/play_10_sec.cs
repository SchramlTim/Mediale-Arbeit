using UnityEngine;
using System.Collections;

public class play_10_sec : MonoBehaviour {
	int counter = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		counter++;
		if (counter == 300) {
			//this.gameObject.GetComponent<ParticleSystem> ().Play ();
			//counter = 0;
		}
	}
}
