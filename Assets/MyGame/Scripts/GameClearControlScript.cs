using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClearControlScript : MonoBehaviour
{
    private string ReturnSceneName;

    public void OnClickStageSelectButton()
    {
        SceneManager.LoadScene("StageSelectScene");
    }

    public void OnClickRetryButton()
    {
        ReturnSceneName = StageControlScript.GetSceneName();

        SceneManager.LoadScene(ReturnSceneName);
    }
}
