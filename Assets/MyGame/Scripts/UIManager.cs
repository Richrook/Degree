using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class UIManager : MonoBehaviour
{
    //インスペクターウィンドウからゲームオブジェクトを設定する
    
    [SerializeField] GameObject OptionPanel;
 
 
 
    // Start is called before the first frame update
    // void Start()
    // {
    //     //BackToMenuメソッドを呼び出す
    //     BackToMenu();
    // }
 
 
    //MenuPanelでXR-HubButtonが押されたときの処理
    //XR-HubPanelをアクティブにする
    public void DisplayOption()
    {
        OptionPanel.SetActive(true);
    }
 
 
    //2つのDescriptionPanelでBackButtonが押されたときの処理
    //MenuPanelをアクティブにする
    public void HideOption()
    {
        OptionPanel.SetActive(false);
    }
}
