using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    [SerializeField]
    private GameObject content;
    [SerializeField]
    private Toggle keyWToggle;
    [SerializeField]
    private Slider pipePeriodSlider;
    [SerializeField]
    private Slider vitalityPeriodSlider;

    private bool isMenuShown;

    void Start()
    {
        GameState.isWkeyEnabled = keyWToggle.isOn;
        OnPipePeriodSlider(pipePeriodSlider.value);
        OnVitalityPeriodSlider(vitalityPeriodSlider.value);

        isMenuShown = content.activeInHierarchy;
        ToggleMenu(isMenuShown);
    }

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            ToggleMenu( ! isMenuShown);
        }
    }
    private void ToggleMenu(bool isShow)
    {
        if(isShow)
        {
            Time.timeScale = 0f;
            isMenuShown = true;
            content.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            isMenuShown = false;
            content.SetActive(false);
        }
    }


    // UI Event handlers
    public void OnCloseButtonClick()
    {
        ToggleMenu(false);
    }
    public void OnControlWkeyChanged(Boolean value)
    {
        GameState.isWkeyEnabled = value;
    }
    public void OnPipePeriodSlider(Single value)
    {
        // value[0..1] ---> time [6..2]
        GameState.pipeSpawnPeriod = 6f - value * (6f - 2f);
    }
    public void OnVitalityPeriodSlider(Single value)
    {
        // value[0..1] ---> time [60..20]
        GameState.vitalityPeriod = 60f - value * (60f - 20f);
    }
}
