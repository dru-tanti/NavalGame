using UnityEngine;

public class Health : MonoBehaviour {
	private int current = 100;
	private int max;
	private SpriteRenderer currentSprite;
	private Sprite undamagedSprite;

	private int damagedThreshold;
	private Sprite damagedSprite;

	private int sinkingThreshold;
	private Sprite sinkingSprite;

	public void Setup(ShipData ship) {
		max					= ship.maxHealth;
		current				= max;
		undamagedSprite		= ship.undamagedSprite;
		damagedThreshold	= ship.damagedThreshold;
		damagedSprite		= ship.damagedSprite;
		sinkingThreshold	= ship.sinkingThreshold;
		sinkingSprite		= ship.sinkingSprite;
		currentSprite		= gameObject.GetComponent<SpriteRenderer>();
	}

	public void TakeDamage(int damage) {
		current -= damage;
		if(current > max) current = max;
		if(current < damagedThreshold) {
			
		}

		if(current < 0) HandleDeath();
	}

	public int GetHealth() {
		return current;
	}

	public void HandleDeath() {

	}
}