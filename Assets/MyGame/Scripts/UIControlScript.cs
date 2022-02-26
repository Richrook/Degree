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
    [Header("ミニマップ")]
    [Tooltip("ミニマップの大きさ")]
    [Range(0.5f, 2.0f)]
    public float minimapScale = 1.0f;
    [Tooltip("ミニマップ用カメラ")]
    public Transform minimapCamera;
    [Tooltip("ミニマップ用カメラで追跡するオブジェクト(プレイヤー)")]
    public Transform target;
    // ミニマップ関連プロパティ (Unity Inspector ウィンドウ非公開)
    Vector3 offset;

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
        UpdateMinimap();
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

    // ミニマップの初期処理
    void initMinimap()
    {
        offset = new Vector3(0.0f, 50 * minimapScale, 0.0f);
    }

    // ミニマップの更新
    void UpdateMinimap()
    {
        minimapCamera.position = target.position + offset;
    }
}
