using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SampleStageController : MonoBehaviour
{
    // ゲームの状態
    enum State
    {
        Ready,
        Play,
        GameOver,
        GameClear
    }
    State state;
    // インスタンスの生成と判定変数の取得
    // public PlayerController player;
    // bool isClear = player.isClear;
    bool isClear = true;
    bool isGameover = false;

    void Start()
    {
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
                    GameStart();
                }
                break;
            case State.Play:
                // ゲームが終了する条件
                if (isGameover == true)
                {
                    GameOver();
                }
                else if (isClear == true)
                {
                    GameClear();
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
        Debug.Log("ready");
    }

    void GameStart()
    {
        state = State.Play;
        Debug.Log("start");
    }

    void GameOver()
    {
        state = State.GameOver;
        Debug.Log("game over");
    }

    void GameClear()
    {
        state = State.GameClear;
        Debug.Log("game clear");
    }
}
