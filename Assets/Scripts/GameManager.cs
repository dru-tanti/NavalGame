using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField]
    private GameState gameState;
    public GameObject ship;

    private void Start() {
        Instantiate(ship);
    }
}
