using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayerEditMain : MonoBehaviour {

	public Image selectedCharacter;
	public Sprite[] characters;
	public Button[] colors;


	int chara_index;


	// Use this for initialization
	void Start () {

		foreach (var item in colors) {
			item.onClick.AddListener (() => {
				selectedCharacter.color = item.colors.normalColor;
			});
		}
	}

	public void LoadScene(string scene_name)
	{
		PlayerStatus.instance.color = selectedCharacter.color;
		PlayerStatus.instance.sprite = selectedCharacter.sprite;

		UnityEngine.SceneManagement.SceneManager.LoadScene (scene_name);
	}

	public void SelectLeft()
	{
		this.chara_index++;
		if (this.characters.Length <= this.chara_index) {
			this.chara_index = 0;
		}
		ApplySprite ();
	}

	public void SelectRight()
	{
		this.chara_index--;
		if (this.chara_index < 0) {
			this.chara_index = this.characters.Length - 1;
		}
		ApplySprite ();
	}

	/// <summary>
	/// キャラ絵を適用する
	/// </summary>
	void ApplySprite()
	{
		this.selectedCharacter.sprite = this.characters [this.chara_index];
	}
}
