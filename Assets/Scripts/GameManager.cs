using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager> {


    [SerializeField] GameObject titleUI;
    [SerializeField] GameObject deadUI;
    [SerializeField] GameObject GOUI;
    [SerializeField] GameObject WinUI;
    [SerializeField] TMP_Text livesUI;
    [SerializeField] TMP_Text TimerUI;
    [SerializeField] Slider healthUI;
    [SerializeField] FloatVariable health;
	[SerializeField] private IntVariable score;
	[SerializeField] GameObject respawn;
    [SerializeField] AudioSource source;
    [SerializeField] public AudioSource pickupSound;
    [Header("Events")]
    //[SerializeField] IntEvent scoreEvent;
    [SerializeField] VoidEvent StartGameEvent;
    [SerializeField] GameObjectEvent respawnEvent;

    public enum State {
        TITLE,
        START_GAME,
        PLAY_GAME,
        DEAD,
        GAME_OVER,
        WIN
    }

    int lives = 0;
    public State state = State.TITLE;
    public float timer = 0;
    public int Lives {get {return lives; } set { lives = value; livesUI.text = "Lives: " + lives; } }
    public float Timer { get { return timer; } set { timer = value; TimerUI.text = string.Format("{0:F1}", timer); } }

    void Start() {
        //scoreEvent.onEventRaised += OnAddPoints;
    }

    void Update() {
        switch (state) {
            case State.TITLE:
                titleUI.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Lives = 3;
                break;
            case State.START_GAME:
                titleUI.SetActive(false);
                Timer = 100;
                score.value = 0;
                lives = 3;
                StartGameEvent.RaiseEvent();
                state = State.PLAY_GAME;
                break;
            case State.PLAY_GAME:
                health.value = 10;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Timer = Timer - Time.deltaTime;
                if (Timer < 0 || Lives == 0) {
                    state = State.GAME_OVER;
                }
                if (score.value >= 170) {
                    state = State.WIN;
                }
                break;
			case State.DEAD:
				//Time.timeScale = 0;
				deadUI.SetActive(true);
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
				break;
            case State.GAME_OVER:
                GOUI.SetActive(true);
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
				break;
            case State.WIN:
                WinUI.SetActive(true);
                break;
		}

        healthUI.value = health.value / 10.0f;
    }

    public void OnAddPoints(int points) {
        print(points);
    }

    public void ONPlayerDead() {
        state = State.DEAD;
        if (Lives <= 0) {
            state = State.GAME_OVER;
        }
            Lives -= 1;
    }

    public void OnRespawn() {
		deadUI.SetActive(false);
		respawnEvent.RaiseEvent(respawn);
        state = State.PLAY_GAME;
		source.Play();
	}

    public void OnRestart() {
        GOUI.SetActive(false);
        OnStartGame();
		source.Play();
	}

    public void OnStartGame() {
        state = State.START_GAME;
        source.Play();
    }

    public void AddTime(float time) {
        timer += time;
    }
}