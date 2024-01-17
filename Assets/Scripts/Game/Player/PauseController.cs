using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PauseController : MonoBehaviour
{
    private bool isPaused = false;
    public UnityEvent Paused;
    public UnityEvent Unpaused;
    private void OnPause(InputValue inputValue)
    {
        TogglePauseMenu();
    }
    public void TogglePauseMenu()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            Paused.Invoke();
        }
        else
        {
            Unpaused.Invoke();
        }
        Time.timeScale = isPaused ? 0 : 1;
    }
}
