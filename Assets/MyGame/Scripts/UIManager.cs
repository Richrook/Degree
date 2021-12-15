using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject PausePanel, SettingPanel;
    private bool pauseGame = false;

    void Start()
    {
        OnUnPause();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseGame = !pauseGame;

            if (pauseGame == true)
            {
                OnPause();
            }
            else
            {
                OnUnPause();
            }
        }
    }

    public void OnPause()
    {
        PausePanel.SetActive(true);     // PausePanelをtrueにする
        Time.timeScale = 0;         // 時間を止める
        pauseGame = true;

        Cursor.lockState = CursorLockMode.None;     // 標準モード
        Cursor.visible = true;      // カーソル表示
    }

    public void OnUnPause()
    {
        PausePanel.SetActive(false);        // PausePanelをfalseにする
        SettingPanel.SetActive(false);      // SettingPanelをfalseにする
        Time.timeScale = 1;
        pauseGame = false;

        Cursor.lockState = CursorLockMode.Locked;   // 中央にロック
        Cursor.visible = false;     // カーソル非表示
    }

    public void OnSetting()
    {
        PausePanel.SetActive(false);    // PausePanelをfalseにする
        SettingPanel.SetActive(true);   // SettingPanelをtrueにする
    }
    public void OnMainMenu()
    {
        SceneManager.LoadScene("TitleScene");
    }
    public void OnRetry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);    // 現在のsceneを再読み込み
    }

    public void OnResume()
    {
        OnUnPause();
    }
}
