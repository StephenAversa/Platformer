using UnityEngine;
using System.Collections;
/// <summary>
/// Enemy skel flip.
/// </summary>
public class EnemySkelFlip : MonoBehaviour {

	/// The enemy reference.
	private EnemySkel enemy;

	/// <summary>
	/// Start this instance.
	/// </summary>
	public void Start(){
		///References
		enemy = gameObject.GetComponentInParent<EnemySkel> ();
	}

	/// <summary>
	/// Raises the trigger enter 2d event.
	/// </summary>
	/// <param name="col">Col.</param>
	public void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Solid" || col.gameObject.tag == "Enemy"){
			enemy.flip = true;
		}
	}
}

