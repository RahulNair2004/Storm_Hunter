using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneManagerHelper
{
    public static string previousSceneName;

    public static void SetPreviousScene()
    {
        previousSceneName = SceneManager.GetActiveScene().name;
    }
}
