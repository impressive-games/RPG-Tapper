using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CircleBHV : MonoBehaviour {
	public Text testSpeed;
	float speed;
	float stopper = -0.05f;

	void Start () {
		speed = Random.Range (4f,7f);
	}

	void Update () {
		testSpeed.text = "Speed: " + speed;
		speed += stopper;
	}

	void FixedUpdate () {
		transform.Rotate (0, speed, 0);
	}
}