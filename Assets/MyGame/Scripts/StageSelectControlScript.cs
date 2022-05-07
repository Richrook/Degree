using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectControlScript : MonoBehaviour
{
    public void OnClickTitleButton()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
