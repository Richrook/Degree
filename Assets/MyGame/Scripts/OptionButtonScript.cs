using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionButtonScript : MonoBehaviour
{
    //インスペクターウィンドウからゲームオブジェクトを設定する

    [SerializeField] GameObject OptionPanel;

    void start()
    {
        HideOption();
    }
    //タイトル画面でButtonが押されたときの処理
    //OptionPanelをアクティブにする
    public void DisplayOption()
    {
        OptionPanel.SetActive(true);
    }

    //OptionPanelでBackButtonが押されたときの処理
    //OptionPanelを非アクティブにする
    public void HideOption()
    {
        OptionPanel.SetActive(false);
    }
}
