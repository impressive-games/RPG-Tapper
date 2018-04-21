using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DialogManager : MonoBehaviour {

	public Text nameText;
	public Text dialogText;
	public GameObject nextSentButton;

	private Queue<string> sentences;

	void Start () {
		sentences = new Queue<string> ();
	}

	public void StartDialog (Dialog dialog) {
		nextSentButton.SetActive (false);
		nameText.text = dialog.name;
		sentences.Clear ();

		foreach (string sentence in dialog.sentences) {
			sentences.Enqueue (sentence);
		}
		nextSentButton.SetActive (true);
		DisplayNextSentence ();
	}

	public void DisplayNextSentence () {
		nextSentButton.SetActive (false);
		if (sentences.Count == 0) {
			EndDialog ();
			return;
		}
		string sentence = sentences.Dequeue ();
		StopAllCoroutines ();
		StartCoroutine (TypeSentence(sentence));
	}

	IEnumerator TypeSentence (string sentence) {
		dialogText.text = "";
		int letterCount = 0;
		foreach (char letter in sentence.ToCharArray()) {
			yield return new WaitUntil (()=> Input.anyKeyDown);				//символы появляются с нажатием любой клавиши или тапа
			dialogText.text += letter;
			letterCount++;

			if (letterCount == sentence.Length) {
				nextSentButton.SetActive (true);
			} else {
				nextSentButton.SetActive (false);
			}
		}
	} 

	/* Этот кусок из оригинального урока. 
	 * Он отвечает за появления символов текста с покадровой задержкой */
//	IEnumerator TypeSentence (string sentence) {
//		dialogText.text = "";
//		foreach (char letter in sentence.ToCharArray()) {
//			dialogText.text += letter;
//			yield return null;
//		}
//	}

	void EndDialog () {
		Debug.Log ("Конец монолога");
	}
}