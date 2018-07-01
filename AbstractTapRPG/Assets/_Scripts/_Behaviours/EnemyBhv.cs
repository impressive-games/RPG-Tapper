using UnityEngine;
using System.Collections;

public class EnemyBhv : MonoBehaviour {
	public GameObject EnemyPrefab;

	Animator anim;
	long enemyHealth;

	void Start () {
		anim = EnemyPrefab.GetComponent<Animator>();
	}

	void Update () {
		CheckShop ();

		if (TapScreen.enemyHaveDMG) {
			anim.SetInteger ("State", 1);
			TapScreen.enemyHaveDMG = false;
		} else {
			anim.SetInteger ("State", 0);
		}
	}

	void CheckShop () {
		if (DopMenu.shopOn) {
			EnemyPrefab.SetActive (false);
		} else {
			EnemyPrefab.SetActive (true);
			anim.SetInteger ("State", 0);
		}
	}
}