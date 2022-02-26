using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageControlScript : MonoBehaviour
{
    // ゲームの状態
    public State state;

    // UIの取得
    public GameObject PauseUI;
    public GameObject SettingUI;
    public GameObject LifePiUI;

    // プレイヤーコントローラーの取得
    PlayerStateMGTScript playerStateMGTScript;

    public static string SceneName;

    void Start()
    {
        playerStateMGTScript = GameObject.Find("Player").GetComponent<PlayerStateMGTScript>();
        SceneName = SceneManager.GetActiveScene().name;
        Play();
    }

    void LateUpdate()
    {
        switch (state)
        {
            case State.Play:
                // エスケープキーでポーズ画面表示
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Pause();
                }
                // ゲーム状況の判定と遷移
                if (playerStateMGTScript.GetIsGameOver())
                {
                    SceneManager.LoadScene("GameOverScene");
                }
                else if (playerStateMGTScript.GetIsGameClear())
                {
                    SceneManager.LoadScene("GameClearScene");
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
        }
    }

    void Play()
    {
        state = State.Play;
        PauseUI.SetActive(false);
        SettingUI.SetActive(false);
        LifePiUI.SetActive(true);
        Time.timeScale = 1;
        Debug.Log(state);
    }

    // ポーズ画面の表示とゲームの一時停止
    void Pause()
    {
        state = State.Pause;
        PauseUI.SetActive(true);
        SettingUI.SetActive(false);
        Time.timeScale = 0;
        Debug.Log(state);
    }

    void Setting()
    {
        state = State.Setting;
        PauseUI.SetActive(false);
        SettingUI.SetActive(true);
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
        Setting();
    }

    // 設定画面からポーズ画面への切り替え
    public void OnToPauseButtonClicked()
    {
        Pause();
    }

    public static string getSceneName()
    {
        return SceneName;
    }
}
