using UnityEngine;
using System.Collections;

public class RipBHV : MonoBehaviour {
	public float moveSpeed = 2f;

	void Start () {
		StartCoroutine (LiveTime ());
	}

	void Update () {
		if (transform.localPosition.x >= 6) {
			moveSpeed = 0;
		}

		transform.Translate (Vector2.right * Time.deltaTime * moveSpeed);

		if (moveSpeed == 0) {
			transform.Translate (Vector2.down * Time.deltaTime * 1.5f);
		}
	}

	IEnumerator LiveTime () {
		yield return new WaitForSeconds (3f);
		Destroy (gameObject);
	}
}