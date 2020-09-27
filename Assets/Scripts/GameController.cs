using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] Spaceship spaceship;
    [SerializeField] GameObject startPanel;
    [SerializeField] GameObject youLosePanel;

    private void Awake()
    {
        youLosePanel.SetActive(false);
        startPanel.SetActive(true);
        SetTimeScale(0f);
    }

    private void Update()
    {
        if (!spaceship.gameObject.activeSelf)
        {
            SpaceshipDestroyed();
        }
    }

    private void SpaceshipDestroyed()
    {
        PauseGame();

    }

    private void PauseGame()
    {
        SetTimeScale(0f);
        youLosePanel.SetActive(true);
    }

    public void RestartGame()
    {
        //TO_DO: restart asteroids - asteroid generator
        youLosePanel.SetActive(false);
        spaceship.gameObject.SetActive(true);
        SetTimeScale(1f);
    }

    public void StartGame()
    {
        startPanel.SetActive(false);
        SetTimeScale(1f);
    }

    private void SetTimeScale(float _value)
    {
        Time.timeScale = _value;
    }
}
