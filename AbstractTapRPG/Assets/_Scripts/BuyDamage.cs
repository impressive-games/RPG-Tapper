using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BuyDamage : MonoBehaviour {
	#region Variables
	public long[] damage;								//массив дополняемого урона при нажатии кнопки 
	public long[] dps;									//массив урона в секунду
	public long[] price;									//массив цен
	public Text[] buttonText;							//массив текста кнопок (что будет отображаться на кнопке)
	public Button[] bttn;								//массив кнопок
	#endregion

	void Update() { 
		CheckPrice (); 
	}

	void CheckPrice() {					//метод проверяет каждый кадр доступность цены для игрока
		for (int i = 0; i < price.Length; i++) {
			if (damage[i] > 0) { 
				buttonText [i].text = "+"+TapScreen.ConvertV6(damage[i]).ToString() + " DMG\t" + 
					"Цена: " + TapScreen.ConvertV6(price[i]).ToString() + "G"; 
			}
			if (dps[i] > 0) { 
				buttonText [i].text = "+" + TapScreen.ConvertV6(dps[i]).ToString() + " DPS\t" + 
					"Цена: " + TapScreen.ConvertV6(price[i]).ToString() + "G"; 
			}

			if (TapScreen.coin < price [i]) { 
						bttn [i].interactable = false;
			} else { 	bttn [i].interactable = true; }

			if (i == buttonText.Length) { i = 0; }
		}
	}

	public void SellDamage (int index) {
		if (TapScreen.coin >= price[index]) {
			TapScreen.coin -= price[index];
			TapScreen.dmg += damage[index];
			TapScreen.dps += dps[index];

			damage [index] += (long)(damage [index] * 0.07f);
			dps [index] += (long)(dps [index] * 0.07f);
			price [index] += (long)(price [index] * 0.07f);
		}
	}
}