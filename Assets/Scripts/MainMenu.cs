using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
	// Reference to the instruction panel and main menu panel
	public GameObject instructionPanel;
	public GameObject mainMenuPanel;

	// Method to start the game
	public void StartGame()
	{
		// Load the game scene (replace "GameScene" with your actual game scene name)
		SceneManager.LoadScene("GameScene");
	}

	// Method to show instructions
	public void ShowInstructions()
	{
		// Activate the instruction panel and deactivate the main menu panel
		instructionPanel.SetActive(true);
		mainMenuPanel.SetActive(false);
	}

	// Method to return to the main menu
	public void BackToMainMenu()
	{
		// Activate the main menu panel and deactivate the instruction panel
		mainMenuPanel.SetActive(true);
		instructionPanel.SetActive(false);
	}
}
