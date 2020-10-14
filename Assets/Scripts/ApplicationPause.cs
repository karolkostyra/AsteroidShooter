using UnityEngine;

public class ApplicationPause : MonoBehaviour
{
    private bool gameStarted = false;

    private void OnApplicationFocus(bool hasFocus)
    {
        if (hasFocus && gameStarted)
        {
            Time.timeScale = 1f;
        }
        else
        {
            Time.timeScale = 0f;
        }
    }

    public void GameStarted(bool _started)
    {
        gameStarted = _started;
    }
}
