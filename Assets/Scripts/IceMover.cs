// Credit: Triston Krebs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceMover : MonoBehaviour
{

	public float speed;

	private Rigidbody2D rb;

	private GameController gameController;

	public float moveWait;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		//rb.velocity = transform.right * speed;
		rb.freezeRotation = true;
		StartCoroutine(move());

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
	IEnumerator move()
	{
		while (true)
		{
			Vector3 val = rb.transform.localPosition;

			rb.transform.localPosition = new Vector3(val.x + speed, val.y, val.z);
			yield return new WaitForSeconds(moveWait);
		}
	}
	void FixedUpdate()
	{
		
	}
}
// Credit: Triston Krebs