// Credit: Triston Krebs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
	private GameController gameController;

	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent<GameController>();

		}
		if (gameController == null)
		{
			Debug.Log("Cannot find 'GameController' script");

		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			gameController.looseCondition();
		}
		else
		{
			Destroy(other.gameObject);
		}
	}
}
// Credit: Triston Krebs