using UnityEngine;

public class Merchant : Ship {
	private bool isChased = false;
    private new void Awake() {
		base.Awake();
	}

	private void FixedUpdate() {
		// Move();
	}

	private void OnCollisionEnter2D(Collision2D other) {
		if(other.transform.tag == "Land") {
			Debug.Log("Hit Land!");
			health.TakeDamage(50);
		}
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if(other.transform.tag == "Port") {
			Debug.Log("In Port!");
			isPorted = true;
		}

		if(other.transform.tag == "Player") {
			Debug.Log("Player Spotted!");
			isChased = true;
		}
	}

	private void OnTriggerExit2D(Collider2D other) {
		if(other.transform.tag == "Port") {
			Debug.Log("Exiting Port!");
			isPorted = false;
		}

		if(other.transform.tag == "Player") {
			Debug.Log("Player Lost!");
			isChased = false;
		}
	}
}
