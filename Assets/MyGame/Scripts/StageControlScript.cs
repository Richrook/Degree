using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageControlScript : MonoBehaviour
{
    // ゲームの状態
    public enum State
    {
        Ready,
        Play,
        Pause,
        Setting,
        GameOver,
        GameClear
    }
    public State state;

    // ポーズ画面と設定画面UIの取得
    public GameObject PauseUI;
    public GameObject SettingUI;

    // プレイヤーコントローラーの取得
    PlayerControlScript playerControlScript;

    void Start()
    {
        playerControlScript = GameObject.Find("Player").GetComponent<PlayerControlScript>();
        Ready();
    }

    void LateUpdate()
    {
        switch (state)
        {
            case State.Ready:
                // クリックでゲーム開始
                if (Input.GetButtonDown("Fire1"))
                {
                    Play();
                }
                break;
            case State.Play:
                // エスケープキーでポーズ画面表示
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Pause();
                }
                if (playerControlScript.GetIsGameOver())
                {
                    GameOver();
                }
                else if (playerControlScript.GetIsClear())
                {
                    GameClear();
                }
                break;
            case State.Pause:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Play();
                }
                break;
            case State.Setting:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Play();
                }
                break;
            case State.GameOver:
                if (Input.GetButtonDown("Fire1"))
                {
                    SceneManager.LoadScene("StageSelectScene");
                }
                break;
            case State.GameClear:
                if (Input.GetButtonDown("Fire1"))
                {
                    SceneManager.LoadScene("StageSelectScene");
                }
                break;
        }
    }

    void Ready()
    {
        state = State.Ready;
        PauseUI.SetActive(false);
        SettingUI.SetActive(false);
        Debug.Log(state);
    }

    void Play()
    {
        state = State.Play;

        PauseUI.SetActive(false);
        SettingUI.SetActive(false);
        Time.timeScale = 1;
        Debug.Log(state);
    }

    void GameOver()
    {
        state = State.GameOver;
        Debug.Log(state);
    }

    void GameClear()
    {
        state = State.GameClear;
        Debug.Log(state);
    }

    // ポーズ画面の表示とゲームの一時停止
    void Pause()
    {
        state = State.Pause;
        PauseUI.SetActive(true);
        Time.timeScale = 0;
        Debug.Log(state);
    }

    // 以下、ポーズ画面でボタンがクリックされたときの処理

    // タイトルに戻る
    public void OnToTitleButtonClicked()
    {
        SceneManager.LoadScene("TitleScene");
    }

    // ゲームを初めからやり直す
    public void OnRetryButtonClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // ポーズ画面から設定画面への切り替え
    public void OnToSettingButtonClicked()
    {
        state = State.Setting;
        PauseUI.SetActive(false);
        SettingUI.SetActive(true);
        Debug.Log(state);
    }

    // 設定画面からポーズ画面への切り替え
    public void OnToPauseButtonClicked()
    {
        state = State.Pause;
        PauseUI.SetActive(true);
        SettingUI.SetActive(false);
        Debug.Log(state);
    }
}
