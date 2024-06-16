using UnityEngine;

public class Health : MonoBehaviour {
	[SerializeField] private int current = 100;
	private int max;
	private SpriteRenderer spriteRenderer;
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
		spriteRenderer		= gameObject.GetComponent<SpriteRenderer>();
	}

	public ShipState TakeDamage(int damage) {
		current -= damage;
		if(current > max) current = max;
		if(current < damagedThreshold) {
			return ShipState.Damaged;
		}

		if(current > sinkingThreshold) {
			return ShipState.Sinking;
		}

		if(current < 0) {
			HandleDeath();
			return ShipState.Sunk;
		}
		return ShipState.Undamaged;
	}

	public int GetHealth() {
		return current;
	}

	public void HandleDeath() {
		Debug.Log("Death!");
	}
}