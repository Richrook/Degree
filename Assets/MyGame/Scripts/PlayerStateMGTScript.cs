using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMGTScript : MonoBehaviour
{
    // シーン内で参照するオブジェクト
    StageControlScript stageControlScript;
    PiControlScript piControlScript;

    GoalControlScript goalControlScript;

    // 気絶状態(プレイヤーを一定時間動けなくする)の管理
    const float STUN_DURATION = 1.0f;
    private float recoverTime = 0.0f;

    // 取得状況の管理
    const int MAX_LIFE = 5;
    private int life = MAX_LIFE;
    const int CAN_CLEAR_PI = 6;
    private int pi = 0;
    private bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        stageControlScript = GameObject.Find("SampleStageController").GetComponent<StageControlScript>();
        goalControlScript = GameObject.Find("Goal").GetComponent<GoalControlScript>();
    }

    // 気絶判定
    private bool IsStun()
    {
        return recoverTime > 0.0f;
    }

    public bool GetIsGameOver()
    {
        return isGameOver;
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
    void OnCollisionStay(Collision collision)
    {
        // QキーでPiを取得
        if (collision.gameObject.tag == "pi")
        {
            string piName = collision.gameObject.name;
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
    void OnCollisionEnter(Collision collision)
    {
        // 敵に当たったらライフを減らす
        // ライフがゼロになったらゲームオーバー
        if (collision.gameObject.tag == "enemy")
        {
            life -= 1;
            // 気絶状態に入る
            string enemyName = collision.gameObject.name;
            Vector3 enemyPos = GameObject.Find(enemyName).transform.position;
            Vector3 playerPos = transform.position;
            playerPos.y = 0;
            enemyPos.y = 0;
            recoverTime = STUN_DURATION;

            Debug.Log("Life: " + life);
            if (life <= 0)
            {
                isGameOver = true;
            }
        }
        // クリア可能な状態であればゲームクリアとする
        else if (collision.gameObject.tag == "goal")
        {
            Debug.Log("collision goal");
            if ((pi >= CAN_CLEAR_PI) && (Input.GetKeyDown(KeyCode.Space)))
            {
                stageControlScript.GameClear();
            }
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
            isGameOver = true;
        }
    }
}
