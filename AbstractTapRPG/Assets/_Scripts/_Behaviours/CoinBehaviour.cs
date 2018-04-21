using UnityEngine;
using System.Collections;

public class CoinBehaviour : MonoBehaviour {
//	float disForce = 35;
	float shootForce;
	Vector2 vec;

	void Start () {
		vec = new Vector2(-Random.Range(0.1f,1.7f), Random.Range(0.8f,2f));			//задает вектор приложения силы на монету
		shootForce = Random.Range (400f, 700f);
		Physics2D.IgnoreLayerCollision (8,8);										//отключает соприкосновение монет друг с другом
		StartCoroutine (LowForce ());
		Destroy (gameObject, 5f);													//уничтожаем монетку через 5 секунд
	}

	void FixedUpdate () {
		gameObject.GetComponent<Rigidbody2D> ().AddForce (vec * shootForce);
		shootForce -= shootForce * 0.75f;
	}

	void OnMouseDown () {
		Destroy (gameObject);
	}

	IEnumerator LowForce () {
		while (shootForce > 0) { 
		yield return new WaitForSeconds (0.1f);
		shootForce -= 50;
		}
	}
}