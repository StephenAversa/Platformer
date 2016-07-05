using UnityEngine;
using System.Collections;

/// <summary>
/// Change level.
/// </summary>
public class ChangeLevel : MonoBehaviour {

	/// <summary>
	/// Changes scene.
	/// </summary>
	public void ChangeToScene()
	{
		///Change to main game.
		Application.LoadLevel(1);
	}
}
