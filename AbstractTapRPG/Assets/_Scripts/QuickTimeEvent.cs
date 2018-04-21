using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QuickTimeEvent : MonoBehaviour {
	public Slider quickTimer;
	public float time;

	void Start () {
		/*при появлении КТЕ проигрывать анимацию*/
		time = Random.Range (1.5f, 5f);
		quickTimer.maxValue = time;
		quickTimer.value = time;
		TapScreen.spawnQTE = true;
		TapScreen.bossFight = true;
	}

	void Update () {
		quickTimer.value -= Time.deltaTime;
		if (quickTimer.value == 0) {
			TapScreen.spawnQTE = false;
			Destroy (gameObject);
		}
		/*удалить выше Дестрой
		добавить метод поражения/конец таймера*/
	}

	void OnMouseDown () {
		/*тут запустить анимацию победы*/
		TapScreen.enemyHealth = 0;
//		TapScreen.spawnQTE = false;
		Destroy (gameObject);
	}
}