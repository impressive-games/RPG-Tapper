using UnityEngine;
using System.Collections;

public class EnemyBhv : MonoBehaviour {

	void Update () {

		if(TapScreen.enemyHaveDMG){
			transform.localScale = transform.localScale - new Vector3 (0.1f, 0.1f, 0);
			gameObject.GetComponent<SpriteRenderer> ().color = new Color (1,0,0,1);
			TapScreen.enemyHaveDMG = false;
		}
	}
}