using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayerEditMain : MonoBehaviour {

	public Image selectedCharacter;
	public Button[] colors;
	public new Text name;
	public Text explain;

	int chara_index;
	DataTableCharacter[] chara_datas;

	// Use this for initialization
	void Start () {

		chara_datas = Resources.LoadAll<DataTableCharacter>("CharacterData");

		foreach (var item in colors) {
			item.onClick.AddListener (() => {
				selectedCharacter.color = item.colors.normalColor;
			});
		}

		ApplyCharacter();
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
		if (this.chara_datas.Length <= this.chara_index) {
			this.chara_index = 0;
		}
		ApplyCharacter ();
	}

	public void SelectRight()
	{
		this.chara_index--;
		if (this.chara_index < 0) {
			this.chara_index = this.chara_datas.Length - 1;
		}
		ApplyCharacter ();
	}

	/// <summary>
	/// キャラ絵を適用する
	/// </summary>
	void ApplyCharacter()
	{
		DataTableCharacter data = this.chara_datas[this.chara_index];
		this.selectedCharacter.sprite = data.sprite;
		this.name.text = data.name;
		this.explain.text = data.explain;
	}
}
