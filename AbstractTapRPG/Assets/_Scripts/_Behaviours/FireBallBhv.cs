using UnityEngine;
using System.Collections;

public class FireBallBhv : MonoBehaviour {
	#region Variables
	[Range(0f,25f)]
	public float speed = 15f;
	#endregion

	void Start () {
		Physics2D.IgnoreLayerCollision (9,8);
	}

	void FixedUpdate () { 
		transform.Translate (speed*Time.deltaTime, 0, 0); 
		if (DopMenu.shopOn) {
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D () {
		TapScreen.enemyHealth -= TapScreen.dps;
		TapScreen.enemyHaveDMG = true;
		Destroy (gameObject);
	}
}