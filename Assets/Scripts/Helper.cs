using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class Helper : MonoBehaviour
{
    public static void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    // Pause Game and unpause game
    public static void Pause()
    {
        Time.timeScale = 0;
    }
    
    public static void Resume()
    {
        Time.timeScale = 1;
    }
}
