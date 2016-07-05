using UnityEngine;
using System.Collections;
/// <summary>
/// Enemy attack.
/// </summary>
public class EnemyAttack : MonoBehaviour {
	/// The player.
	private PlayerControl Player;

	/// <summary>
	/// Start this instance.
	/// </summary>
	public void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerControl> ();
	}
	
	/// <summary>
	/// Raises the trigger enter2 d event.
	/// </summary>
	/// <param name="col">Col.</param>
	public void OnTriggerEnter2D(Collider2D col){
		if (col.CompareTag ("Player")) {
			///Inflict player damage.
			Player.inflictDamage (1);
			StartCoroutine (Player.KnockBack (0.05f, 200, -(col.transform.position - transform.position).normalized));
			}
	}

}

