// Credit: Triston Krebs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb2d;
	private GameController gameController;
	private bool ice;
	private GameObject iceberg;
	private Vector3 prev;

	public float speed;
	public float moveWait;

	void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
		ice = false;
		prev = new Vector3(0, 0, 0);
		iceberg = null;


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

	void FixedUpdate()
	{
		float moveVertical = Input.GetAxis("Vertical");
		float moveHorizotal = Input.GetAxis("Horizontal");


		if (ice)
		{
			Vector3 diff = iceberg.transform.localPosition - prev;
			Vector3 cur = rb2d.transform.localPosition;
			rb2d.transform.localPosition = new Vector3(cur.x + diff.x, cur.y + diff.y, cur.z);
			prev = iceberg.transform.localPosition;
		}


		Vector3 val = rb2d.transform.localPosition;

		rb2d.transform.localPosition = new Vector3(val.x + (moveHorizotal * speed), val.y + (moveVertical * speed), val.z);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Finish"))
		{
			gameController.WinCondition();
		}

		if(other.gameObject.CompareTag("IceBerg"))
		{
			ice = true;
			iceberg = other.gameObject;
			prev = iceberg.transform.localPosition;
		}

		if (other.gameObject.CompareTag("Empty"))
		{
			gameController.looseCondition();
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("IceBerg"))
		{
			ice = false;
		}
	}

}
// Credit: Triston Krebs