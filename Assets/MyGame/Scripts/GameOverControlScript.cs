using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverControlScript : MonoBehaviour
{
    private string ReturnSceneName;
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
