using UnityEngine;
using System.Collections;

/// <summary>
/// Spikes.
/// </summary>
public class Spikes : MonoBehaviour {

	/// The player object.
	private PlayerControl Player;
	
	/// <summary>
	/// Start this instance.
	/// </summary>
	public void Start () {
		///Find the player in the game by its unique tag.
		Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl> ();
	}

	/// <summary>
	/// Raises the trigger enter 2d event.
	/// </summary>
	/// <param name="col">Col.</param>
	public void OnTriggerEnter2D(Collider2D col){
		///Check if the collision is the player.
		if (col.CompareTag("Player")){
			///Inflict damage on the player
			Player.inflictDamage(1);
			//Apply knockback to the player.
			StartCoroutine(Player.KnockBack(0.04f,400,Player.transform.position));
		}
	}

}
