using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    GameObject menu;

    ControllerActions controllerControls;
    KeyboardActions keyboardControls;

    void Awake()
    {
        Time.timeScale = 1;

        controllerControls = new ControllerActions();
        controllerControls.ControllerGameplay.PauseMenu.started += ctx => InteractWithPauseMenu();

        keyboardControls = new KeyboardActions();
        keyboardControls.KeyboardGameplay.PauseMenu.started += ctx => InteractWithPauseMenu();
    }

    private void OnEnable()
    {
        controllerControls.ControllerGameplay.Enable();
        keyboardControls.KeyboardGameplay.Enable();
    }

    private void OnDisable()
    {
        controllerControls.ControllerGameplay.Disable();
        keyboardControls.KeyboardGameplay.Disable();
    }

    void InteractWithPauseMenu()
    {
        if (!menu.active)
        {
            menu.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            menu.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
