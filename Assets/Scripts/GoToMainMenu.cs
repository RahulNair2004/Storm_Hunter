using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMainMenu : MonoBehaviour
{
    // This method will be called when the button is clicked
    public void OnButtonClick()
    {
        // Load the Main Menu scene
        SceneManager.LoadScene("Main Menu"); // Replace "MainMenu" with the actual name of your main menu scene
    }
}
