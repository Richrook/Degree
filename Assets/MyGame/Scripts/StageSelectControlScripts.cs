using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectControlScripts : MonoBehaviour
{
    enum State
    {
        StageSelect,
        Option
    }
    State state;

    // ステージセレクト画面と設定画面UIの取得
    public GameObject StageSelectUI;
    public GameObject OptionUI;

    void Start()
    {
        StageSelect();
    }

    void LateUpdate()
    {
        switch (state)
        {
            case State.StageSelect:
                // エスケープキーでオプション画面に
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Option();
                }
                break;

            case State.Option:
                // エスケープキーでステージセレクト画面に
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    StageSelect();
                }
                break;
        }
    }

    void StageSelect()
    {
        state = State.StageSelect;
        StageSelectUI.SetActive(true);
        OptionUI.SetActive(false);
        Debug.Log(state);
    }

    void Option()
    {
        state = State.Option;
        StageSelectUI.SetActive(false);
        OptionUI.SetActive(true);
        Debug.Log(state);
    }
    public void OnClickTitleButton()
    {
        SceneManager.LoadScene("TitleScene");
    }
    public void OnClickCloseButton()
    {
        StageSelect();
    }
}
