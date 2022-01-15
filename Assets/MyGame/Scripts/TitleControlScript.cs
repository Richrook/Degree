using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleControlScript : MonoBehaviour
{
    public GameObject SettingUI;
    void start()
    {
        OnClickCloseButton();
    }
    public void OnClickStageSelectButton()
    {
        SceneManager.LoadScene("StageSelectScene");
    }
    public void OnClickOptionButton()
    {
        SettingUI.SetActive(true);
    }
    public void OnClickCloseButton()
    {
        SettingUI.SetActive(false);
    }
}
