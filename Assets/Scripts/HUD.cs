using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/// <summary>
/// HU.
/// </summary>
public class HUD : MonoBehaviour {
	/// The image array for the health.
	public Sprite[] Health_Strip;
	/// The image for the health
	public Image HeartUI;
	/// The player.
	private PlayerControl Player;

	/// <summary>
	/// Start this instance.
	/// </summary>
	public void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerControl> ();
	
	}
	
	/// <summary>
	/// Update this instance.
	/// </summary>
	public void Update () {
		///Update the heart UI to match the current player health.
		if (Player.curHealth >= 0) {
			HeartUI.sprite = Health_Strip [Player.curHealth];
		}
	}

}
