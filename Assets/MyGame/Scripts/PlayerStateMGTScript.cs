using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStateMGTScript : MonoBehaviour
{
    // シーン内で参照するオブジェクト
    StageControlScript stageControlScript;
    PiControlScript piControlScript;

    GoalControlScript goalControlScript;

    public Image img;

    // 気絶状態(プレイヤーを一定時間動けなくする)の管理
    const float INVINCIBLE_TIME = 1.0f;
    private float remainingTime = 0.0f;

    // 取得状況の管理
    const int MAX_LIFE = 5;
    private int life = MAX_LIFE;
    const int CAN_CLEAR_PI = 6;
    private int pi = 0;

    // Start is called before the first frame update
    void Start()
    {
        stageControlScript = GameObject.Find("StageController").GetComponent<StageControlScript>();
        goalControlScript = GameObject.Find("Goal").GetComponent<GoalControlScript>();
        img.color = Color.clear;
    }

    void Update()
    {
        if (isInvincible())
        {
            remainingTime -= Time.deltaTime;
        }
        this.img.color = Color.Lerp(this.img.color, Color.clear, Time.deltaTime);
    }

    // 気絶判定
    private bool isInvincible()
    {
        return remainingTime > 0.0f;
    }

    public int getLife()
    {
        return life;
    }

    public int getPi()
    {
        return pi;
    }

    // 衝突判定
    void OnTriggerStay(Collider Collider)
    {
        // QキーでPiを取得
        if (Collider.gameObject.tag == "pi")
        {
            string piName = Collider.gameObject.name;
            piControlScript = GameObject.Find(piName).GetComponent<PiControlScript>();
            if ((piControlScript.getIsValid()) && (Input.GetKeyDown(KeyCode.Q)))
            {
                pi += 1;
                piControlScript.changePiState();
                // Pi取得時の関数を呼び出す
                Debug.Log("Pi: " + pi);
            }
            // Piを6個取得したらクリア可能状態にする
            if (pi == CAN_CLEAR_PI)
            {
                goalControlScript.changeGoal();
            }
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        // 敵に当たったらライフを減らす
        // ライフがゼロになったらゲームオーバー
        if (collider.gameObject.tag == "enemy" && !isInvincible())
        {
            life -= 1;
            remainingTime = INVINCIBLE_TIME;
            this.img.color = new Color(0.5f, 0f, 0f, 0.5f);
            Debug.Log("Life: " + life);
            if (life <= 0)
            {
                stageControlScript.GameOver();
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        // クリア可能な状態であればゲームクリアとする
        if ((collision.gameObject.tag == "goal") && (pi >= CAN_CLEAR_PI))
        {
            stageControlScript.GameClear();
        }
        // ライフを回復
        else if (collision.gameObject.tag == "life")
        {
            if (life < MAX_LIFE)
            {
                life += 1;
            }
            Destroy(collision.gameObject);
            Debug.Log("Life: " + life);
        }
        // 落下したらゲームオーバーとする
        else if (collision.gameObject.tag == "abyss")
        {
            stageControlScript.GameOver();
        }
    }
}
