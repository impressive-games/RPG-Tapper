using UnityEngine;
using System.Collections;

public class EnemyBhv : MonoBehaviour {
	Animator anim;

	void Start () {
		anim = GetComponent<Animator>();
	}
	void Update () {

		if (TapScreen.enemyHaveDMG) {
			Debug.Log ("enemyHaveDMG = true");
			anim.SetInteger ("State", 1);
//			transform.localScale = transform.localScale - new Vector3 (0.1f, 0.1f, 0);
//			gameObject.GetComponent<SpriteRenderer> ().color = new Color (1,0,0,1);
			TapScreen.enemyHaveDMG = false;
		} else {
			anim.SetInteger ("State", 0);
		}
	}
}