using UnityEngine;

public class GameManager1 : MonoBehaviour
{
    public TransitionManager1 transitionManager; // Reference to the TransitionManager script

    private void Start()
    {
        // For demonstration, we'll start the transition when the game starts
        // You can replace this with any condition or event that triggers the transition
        transitionManager.StartTransition();
    }
}
