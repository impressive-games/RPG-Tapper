using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class DopMenu : MonoBehaviour {
	public GameObject dopMenu;
	public GameObject shopPanel;

	public static bool shopOn;						//переменная отвечает за определение состояния магазина

//-----------------------------------------------

	void Start () {
		shopOn = false;
		shopPanel.SetActive (false);
		dopMenu.SetActive (false);
	}

	void Update () { CheckShopStatus (); }

	public void OpenShop () { shopPanel.SetActive (!shopPanel.activeSelf); }

	public void OpenDopMenu () {
		dopMenu.SetActive (!dopMenu.activeSelf);
		if (!dopMenu.activeSelf && shopPanel.activeSelf) { shopPanel.SetActive (false); }
	}

	public void CheckShopStatus () {
		if (shopPanel.activeSelf) { shopOn = true;
		} else { 					shopOn = false; }
	}
}