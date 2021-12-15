using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectButtonScript : MonoBehaviour
{
    public void OnClickStageSelectButton()
    {
        SceneManager.LoadScene("StageSelectScene");
    }
}
