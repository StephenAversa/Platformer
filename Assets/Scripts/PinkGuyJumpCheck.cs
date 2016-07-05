using UnityEngine;
using System.Collections;
/// <summary>
/// Pink guy jump check.
/// </summary>
public class PinkGuyJumpCheck : MonoBehaviour {
	/// The enemy reference
	private PinkGuy enemy;

	/// <summary>
	/// Start this instance.
	/// </summary>
	public void Start(){
		enemy = gameObject.GetComponentInParent<PinkGuy> ();
	}

	/// <summary>
	/// Raises the trigger enter 2d event.
	/// </summary>
	/// <param name="col">Col.</param>
	public void OnTriggerEnter2D(Collider2D col){
		enemy.jumpCheck = false;
	}

	/// <summary>
	/// Raises the trigger stay 2d event.
	/// </summary>
	/// <param name="col">Col.</param>
	public void OnTriggerStay2D(Collider2D col){
		enemy.jumpCheck  = false;
	}

	/// <summary>
	/// Raises the trigger exit 2d event.
	/// </summary>
	/// <param name="col">Col.</param>
	public void OnTriggerExit2D(Collider2D col){
		enemy.jumpCheck  = true;
	}
}
