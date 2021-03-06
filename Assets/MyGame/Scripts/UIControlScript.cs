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
    [Tooltip("ミニマップの広さ")]
    [Range(1.0f, 10.0f)]
    public float minimapScale;
    // ミニマップ関連プロパティ (Unity Inspector ウィンドウ非公開)
    Transform target;
    GameObject minimapCamera;
    Vector3 offset;

    // プレイヤーコントローラーの取得
    PlayerStateMGTScript playerStateMGTScript;

    void Start()
    {
        playerStateMGTScript = GameObject.Find("Player").GetComponent<PlayerStateMGTScript>();
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
        target = GameObject.Find("Player").transform;
        minimapCamera = GameObject.Find("MinimapCamera");
        minimapCamera.GetComponent<Camera>().orthographicSize = minimapScale;
    }

    // ミニマップの更新
    void UpdateMinimap()
    {
        offset = new Vector3(0.0f, 100.0f, 0.0f);
        minimapCamera.transform.position = target.position + offset;
    }
}
