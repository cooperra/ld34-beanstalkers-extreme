using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum GameStates{
    RUNNING,
    PAUSED,
    LOSE,
    MIDLEVEL,
    LOADING,
    CREDITS,
    PAUSED_NO_UI
}

public class StateManager : MonoBehaviour{

    public static StateManager Instance { get; private set; }

    public GameStates CurrentState { get; private set; }

/*
    public GameObject RunningUI;
    public GameObject PauseUI;
    public GameObject LoseUI;
*/
    void Awake(){
        SetState(GameStates.RUNNING);
        if (Instance == null)
            Instance = this;

    }

    bool holding = false;
    void Update(){
        if (Input.GetAxis("Cancel") != 0 && !holding){
            TogglePause();
            holding = true;
        }

        if (Input.GetAxis("Cancel") == 0)
            holding = false; 
        if (Input.GetKey("g")){
            SetState(GameStates.LOSE);
        }
    }

    public void SetState(GameStates stateToChange){
        CurrentState = stateToChange;
        /*
        if (CurrentState == GameStates.RUNNING){
            RunningUI.SetActive(true);
            PauseUI.SetActive(false);
            LoseUI.SetActive(false);
        }
        else if (CurrentState == GameStates.PAUSED){
            RunningUI.SetActive(false);
            PauseUI.SetActive(true);
            LoseUI.SetActive(false);
        }
        else if (CurrentState == GameStates.LOSE){
            RunningUI.SetActive(false);
            PauseUI.SetActive(false);
            LoseUI.SetActive(true);
        }*/
    }

    public void TogglePause(){
        if (CurrentState == GameStates.PAUSED)
            SetState(GameStates.RUNNING);
        else if (CurrentState == GameStates.RUNNING)
            SetState(GameStates.PAUSED);
    }

    public bool IsRunning(){
        return CurrentState == GameStates.RUNNING ? true : false;
    }

    public bool IsPaused(){
        return CurrentState != GameStates.RUNNING ? true : false;
    }

    public void ResumeButton(){
        SetState(GameStates.RUNNING);
    }
}
