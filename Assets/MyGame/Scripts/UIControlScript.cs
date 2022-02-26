using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIControlScript : MonoBehaviour
{
    // ライフのアイコンを格納
    public GameObject[] lifeIcons;

    // Pi取得数
    public Text piCount;

    // プレイヤーコントローラーの取得
    PlayerStateMGTScript playerStateMGTScript;

    void Start()
    {
        playerStateMGTScript = GameObject.Find("Player").GetComponent<PlayerStateMGTScript>();
    }

    void LateUpdate()
    {
        // ライフとPiのUIを更新
        UpdateLife();
        UpdatePiCount();
    }

    // ライフの表示数を管理
    private void UpdateLife()
    {
        int life = playerStateMGTScript.getLife();
        for (int i = 0; i < lifeIcons.Length; i++)
        {
            if (i < life)
            {
                lifeIcons[i].SetActive(true);
            }
            else
            {
                lifeIcons[i].SetActive(false);
            }
        }
    }

    // Piの取得数を管理
    private void UpdatePiCount()
    {
        int pi = playerStateMGTScript.getPi();
        piCount.text = pi + " / 8";
    }
}
