using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TapScreen : MonoBehaviour {

	#region Variables
	public GameObject QTEPrefab;					//Указываем на КТЕ префаб
	public GameObject coinPrefab;					//Указываем на монетку
	public GameObject RipPrefab;
	public GameObject Hero;							//Указываем на героя
	public GameObject Enemy;						//Указываем на врага
	public Text startText;							//Показывает количество убитых врагов. Позже - количество полученного золота 
	public Text enmHealthTxt;						//Обозначение жизни врага

	long enmHealthNeed = 10;						//Начальное здоровье врага (столько урона нужно нанести)
	long countLevel = 0;							//Количество убитых врагов
	long countLevel10 = 0;							//Количество пройденных уровней, кратных 10 
	long dropCoin = 5;								//Начальное кол-во выпадающих монет с врага
	bool spawnEnemy = false;						//Отвечает за появления врагов
	string coinOut;
	string dmgOut;
	string dpsOut;
	string enmHOut;

	public static string[] calculate = new string[]{"","K","M","B","T","qd","qn"};
	public static long enemyHealth = 10;			//Начальное здоровье врага
	public static long dps = 1;						//Начальный урон в секунду
	public static long dmg = 1;						//Начальный урон за нажатие
	public static long coin = 0;					//Начальное кол-во медных монет
	public static bool stopCollecting = false;		//Отвечает за остановку сбора монет
	public static bool spawnQTE = false;
	public static bool bossFight = false;
	public static bool enemyHaveDMG = false;
	#endregion

	void Update () {
		TapNew ();				//отвечает за счет тапов по экрану
		CheckShop ();			//проверяет активность магазина
		EnemyDeath ();			//действие, если враг погиб
		CollectCoin ();			//отвечает за сбор монет

//		BossFight ();

		DropButtons ();			//Trash void


		//-----------------OUTPUT------------------
		enmHOut = ConvertV6 (enemyHealth);
		dmgOut = ConvertV6 (dmg);
		dpsOut = ConvertV6 (dps);
		coinOut = ConvertV6 (coin);

		enmHealthTxt.text = enmHOut;
		startText.text = 
			"PlayerNickname" + 
			"\n--------------" +
			"\n DMG: " + dmgOut +
			"\n DPS: " + dpsOut + 
			"\nGold: " + coinOut + 
			"\nKill: " + countLevel.ToString();
	}
		
	void TapNew () {									//новый метод тапов работает только на телефонах
		foreach(Touch touch in Input.touches) {			//перебираем все нажатия и их состояния
			if (touch.phase == TouchPhase.Began && !DopMenu.shopOn) { 
				UnitAction (); 
			}
			if (touch.phase == TouchPhase.Ended && !DopMenu.shopOn) { 
				UnitDeaction (); 
			}
		}
	}
		
	void EnemyDeath () {
		if (enemyHealth <= 0) {
			spawnEnemy = true;
			countLevel++;
			enmHealthNeed += (long)(enmHealthNeed * 0.2f);
			enemyHealth = enmHealthNeed;

			Instantiate (RipPrefab, Enemy.transform.position, Quaternion.identity);

			for (int dropCoinCount = Random.Range (2,5); dropCoinCount > 0; dropCoinCount--) {
				Instantiate (coinPrefab, new Vector2 (Enemy.transform.position.x, Enemy.transform.position.y + 3f), Quaternion.identity);
			}
		} else {
			spawnEnemy = false;
		}
	}

	void UnitAction () {
		if (stopCollecting == false) { 
			enemyHealth -= dmg;
			enemyHaveDMG = true;
		}
		Hero.transform.Translate(new Vector3 (0.5f, 0, 0));
	}

	void UnitDeaction () {
		Hero.transform.Translate(new Vector3 (-0.5f, 0, 0));
	}

	/*void BossFight () {
		if (countLevel % 10 == 0 && countLevel != 0) {
			Debug.Log ("Alarma!! BossFoght!");
		}
	}*/

	void CheckShop () {
		if (DopMenu.shopOn) {
			Enemy.SetActive (false);
			enmHealthTxt.text = "";
		} else {
			Enemy.SetActive (true);
		}
	}

	void CollectCoin ()	{
		if (spawnEnemy && stopCollecting == false) {
			coin += dropCoin;

			if (countLevel % 10 == 0) {
				countLevel10++;
				dropCoin *= (long)(0.7f * countLevel10);
			}
		}
	}
		
	public static string ConvertV6 (long first) {
		int stepPow = 0;
		int step = (int)Mathf.Log10 (first) + 1;
		string second;

		if (step < 4) {
			second = first.ToString();
			return second;
		} else {
			if (step % 3 > 0) {
				stepPow = Mathf.RoundToInt (step / 3);
			} else {
				stepPow = Mathf.RoundToInt (step / 3) - 1;
			}

			second = (first / Mathf.Pow(10, (3 * stepPow))).ToString ("0.00") + calculate[stepPow];
			return second;
		}
	}

	#region Tarsh voids
	void DropButtons () {
		if (Input.GetButtonDown("TapTap")) {
			UnitAction();
		}
		if (Input.GetButtonUp("TapTap")) {
			UnitDeaction();
		}
		if (Input.GetButtonDown("KillEnemy")) {
			enemyHealth = 0;
		}
		if (Input.GetButtonDown("GetGold")) {
			for (int dropCoinCount = Random.Range (1,5); dropCoinCount > 0; dropCoinCount--) {
				Instantiate (coinPrefab, new Vector2 (Enemy.transform.position.x, Enemy.transform.position.y + 2f), Quaternion.identity);
			}
		}
	}
//	void ConvertCoin () {
//
//		/*Ниже написан очень неудобный костыль, но пока ничего лучше я придумать не могу*/
//
//		int step = (int)Mathf.Log10 (coin) + 1;		//узнаем количество знаков в числе
//		//		Debug.Log (step);
//
//		if (step < 4) {
//			coinOut = coin.ToString("0.00"); 
//		}
//		if (step >= 4) {
//			coinOut = (coin / (Mathf.Pow (10, 3))).ToString("##.00") + "K"; 
//		}
//		if (step >= 7) {
//			coinOut = (coin / (Mathf.Pow (10, 6))).ToString("##.00") + "M";
//		}
//		if (step >= 10) {
//			coinOut = (coin / (Mathf.Pow (10, 9))).ToString("##.00") + "B";
//		}
//		if (step >= 13) {
//			coinOut = (coin / (Mathf.Pow (10, 12))).ToString("##.00") + "T";
//		}
//		if (step >= 16) {
//			coinOut = (coin / (Mathf.Pow (10, 15))).ToString("##.00") + "aa";
//		}
//		if (step >= 19) {
//			coinOut = (coin / (Mathf.Pow (10, 18))).ToString("##.00") + "ab";
//		}
//	}
	#endregion
}