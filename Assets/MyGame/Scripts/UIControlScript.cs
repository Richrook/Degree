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

    // ミニマップ関連プロパティ
    [Range(0.1f, 2.0f)]
    public float minimapScale = 1.0f;
    uint distMinimapCamera;

    // プレイヤーコントローラーの取得
    PlayerControlScript playerControlScript;

    void Start()
    {
        playerControlScript = GameObject.Find("Player").GetComponent<PlayerControlScript>();
        initMinimap();
    }

    void LateUpdate()
    {
        // ライフとPiのUIを更新
        UpdateLife();
        UpdatePiCount();
        UpdateMinimap();
    }

    // ライフの表示数を管理
    private void UpdateLife()
    {
        int life = playerControlScript.getLife();
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
        int pi = playerControlScript.getPi();
        piCount.text = pi + " / 8";
    }

    // ミニマップの初期処理
    void initMinimap()
    {
        distMinimapCamera = (uint)(300 * minimapScale);
    }

    // ミニマップの更新
    void UpdateMinimap()
    {

    }
}
