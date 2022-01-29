using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameClearControlScript : MonoBehaviour
{
    public string ReturnSceneName;
    public Text piCount;
    void Start()
    {
        int pi = PlayerControlScript.getPi();
        piCount.text = pi + " / 8";
    }

    public void OnClickStageSelectButton()
    {
        SceneManager.LoadScene("StageSelectScene");
    }
    public void OnClickRetryButton()
    {
        ReturnSceneName = StageControlScript.getSceneName();

        SceneManager.LoadScene(ReturnSceneName);
    }
}
