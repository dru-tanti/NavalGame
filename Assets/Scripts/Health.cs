using UnityEngine;

public class Health : MonoBehaviour {
	private int value = 100;

	public void SetValue(int health) {
		value = health;
	}

	public void TakeDamage(int damage) {
		value -= damage;
	}

	public int GetHealth() {
		Destroy(gameObject);
		return value;
	}
}