using UnityEngine;

public class ClosePopup : MonoBehaviour
{
    public GameObject popupWindow; // The popup window GameObject

    // Method to close the popup
    public void ClosePopupWindow()
    {
        popupWindow.SetActive(false); // Deactivates the popup
    }
}
