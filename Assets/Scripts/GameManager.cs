using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : Singleton<GameManager> {


    [SerializeField] GameObject titleUI;
    [SerializeField] TMP_Text livesUI;
    [SerializeField] TMP_Text TimerUI;

    public enum State {
        TITLE,
        START_GAME,
        PLAY_GAME,
        GAME_OVER
    }

    int lives = 0;
    public State state = State.TITLE;
    public float timer = 0;
    public int Lives {get {return lives; } set { lives = value; livesUI.text = "Lives: " + lives; } }
    public float Timer { get { return timer; } set { timer = value; TimerUI.text = string.Format("{0:F1}", timer); } }

    void Start() {

    }

    void Update() {
        switch (state) {
            case State.TITLE:
                titleUI.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                break;
            case State.START_GAME:
                titleUI.SetActive(false);
                Timer = 180;
                Lives = 3;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                state = State.PLAY_GAME;
                
                break;
            case State.PLAY_GAME:
                Timer = Timer - Time.deltaTime;
                if (Timer < 0 || Lives == 0) {
                    state = State.GAME_OVER;
                }
                break;
            case State.GAME_OVER:
                break;
        }
    }



    public void OnStartGame() {
        state = State.START_GAME;
    }
}