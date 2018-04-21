using UnityEngine;
using System.Collections;

public class CompanionBehav : MonoBehaviour {
	public GameObject target;
	public GameObject bullet;

	bool upVector = true;
	float speed = 0.01f;

	//----------------------------------

	void Start() {
		StartCoroutine (MoveCompanion());
		StartCoroutine (SpawnFireBall());
	}

	void Update() {
		if (upVector) { gameObject.transform.position += new Vector3 (0, 0.5f, 0) * speed;
		} else {		gameObject.transform.position -= new Vector3 (0, 0.5f, 0) * speed; }
	}

	public IEnumerator SpawnFireBall() {
		while (true) {
			if (!DopMenu.shopOn) {
				yield return new WaitForSeconds (1f);
				Instantiate (bullet, new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y), 		//Перенос части строки
					Quaternion.FromToRotation (new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y), -new Vector2 (target.transform.position.x, target.transform.position.y +2f))); 
			} else {
				yield return new WaitForSeconds (1f);;
			}
		}
	}

	IEnumerator MoveCompanion() {
		while (true) {
			if (upVector) {
				yield return new WaitForSeconds (1.5f);
				upVector = false;
			} else {
				yield return new WaitForSeconds (1.5f);
				upVector = true;
			}
		}
	}
}