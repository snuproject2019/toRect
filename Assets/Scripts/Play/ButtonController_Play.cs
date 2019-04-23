﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/*
 *  ButtonController_Play 는 버튼 입력에 따른 반응들을 관리한다.
 * 
 * 
 * 
 * 
 */
public class ButtonController_Play : MonoBehaviour
{

    public GameObject SoundOnButton;
    public GameObject SoundOffButton;
    public GameObject AllChangeModeButton;
    public GameObject RotateChangeModeButton;
    public GameObject SlideChangeModeButton;
    public GameObject RankingButton;
    public GameObject RankPage;
    public GameObject EC;
    private EventController ec;
    public GameObject GC;
    private GameController gc;
    public GameObject FormulaBoard;
    
    private bool formulaBoardState;
    private bool isFormulaBoardSelectable;

    public void Awake()
    {
        isFormulaBoardSelectable = true;
        formulaBoardState = false;
        SoundOnButton.SetActive(false);
        SoundOffButton.SetActive(true);
        AllChangeModeButton.SetActive(true);
        RotateChangeModeButton.SetActive(false);
        SlideChangeModeButton.SetActive(false);
        RankPage.SetActive(false);
        ec = EC.GetComponent<EventController>();
        gc = GC.GetComponent<GameController>();

        int currentMode = PlayerPrefs.GetInt("Mode");

    }

    public void Totitle()
    {
        SceneManager.LoadScene("Title");
        return;
    }

    public void RestartChallenge()
    {
        PlayerPrefs.SetInt("Mode", 0);
        SceneManager.LoadScene("Play");
        return;
    }

    public void GameClose()
    {
        Application.Quit();
    }

    public void SoundOn()
    {
        PlayerPrefs.SetFloat("isSoundOn", 1f);
        AudioListener.volume = 1f;
        return;
    }

    public void SoundOff()
    {
        PlayerPrefs.SetFloat("isSoundOn", 0f);
        AudioListener.volume = 0f;
        return;
    }

    public void ToRank()
    {
        RankPage.SetActive(true);
        return;
    }

    // Temp - Solve 디버깅용 즉시클리어 버튼
    public void ImmediateWin()
    {
        ec.GameManager(2);
        return;
    }

    public void FormulaBoardToggle()
    {
        Debug.Log("FormulaBoardToggle called");
        if (!isFormulaBoardSelectable)
        {
            FormulaBoard.SetActive(false);
            formulaBoardState = false;
            return;
        }

        if(formulaBoardState == false)
        {
            FormulaBoard.SetActive(true);
            formulaBoardState = true;
        }
        else
        {
            FormulaBoard.SetActive(false);
            formulaBoardState = false;
        }
        return;
    }

    public void FormulaSelect(int which)
    {
        if(which == gc.getFormulaAnswer())
        {
            ec.SetFormulaBonus(true);
        }
        else
        {
            ec.SetFormulaBonus(false);
            
        }
        isFormulaBoardSelectable = false;
        FormulaBoard.SetActive(false);
        formulaBoardState = false;
        return;
    }

    public void NextChapter()
    {
        int currentMode = PlayerPrefs.GetInt("Mode");
        int currentGame = PlayerPrefs.GetInt("Game");
        if(currentMode == 0)
        {
            // TODO : 만약 단계별 클리어화면 추가되면 여기에서 작업한다.
            PlayerPrefs.SetInt("Mode", 1);
        }
        else if(currentMode == 1)
        {
            PlayerPrefs.SetInt("Mode", 2);
        }
        else if(currentMode == 2)
        {
            PlayerPrefs.SetInt("Mode", 3);
        }
        else
        {
            PlayerPrefs.SetInt("Mode", 0);
        }
        SceneManager.LoadScene("Play");
        return;
    }

}
