using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionController : MonoBehaviour {
	/*это дерьмо не работает, только зря время потратил*/

	InputField input;
	public static string playerNickData;

	void Awake () {
		input = GameObject.Find ("InputField").GetComponent<InputField> ();
	}

	public void GetInput (string playerNickname) {
		playerNickData = playerNickname;
		Debug.Log ("playerNickData: " + playerNickname);
		PlayerPrefs.SetString ("playerNickData", playerNickData);

		input.text = "";

		PlayerPrefs.Save ();
	}
}