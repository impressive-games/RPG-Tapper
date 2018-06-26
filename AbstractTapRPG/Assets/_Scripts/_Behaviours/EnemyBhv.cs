using UnityEngine;
using System.Collections;

public class EnemyBhv : MonoBehaviour {
	Animator anim;

	void Start () {
		anim = GetComponent<Animator>();
	}

	void Update () {

		if (TapScreen.enemyHaveDMG) {
			anim.SetInteger ("State", 1);
			TapScreen.enemyHaveDMG = false;
		} else {
			anim.SetInteger ("State", 0);
		}
	}
}