using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class ShipGameMode : MonoBehaviour
{
    public PlayerActions player;
    public TextMeshProUGUI healthDisplay;
    public bool gameOver = false;
    public TextMeshProUGUI gameOverDisplay;
    public UnityEngine.UI.Slider healthSlider;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthDisplay.text = "Health: " + player.health;
        gameOverDisplay.gameObject.SetActive(gameOver);
		healthSlider.value = player.health;
	}
}
