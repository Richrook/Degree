using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlScript : MonoBehaviour
{
    //動作テスト用の変数
    Vector3 moveDirection = Vector3.zero;
    public float gravity;
    public float speedRun;
    public float speedJump;

    // シーン内で参照するオブジェクト
    CharacterController controller;
    StageControlScript stageControlScript;
    PiControlScript piControlScript;

    // 気絶状態(プレイヤーを一定時間動けなくする)の管理
    const float StunDuration = 1.0f;
    private float recoverTime = 0.0f;

    // クリア可能判定
    private bool allowClear = false;

    // 取得状況の管理
    const int maxLife = 5;
    private int life = 5;
    const int canClearPi = 6;
    private int pi = 0;
    private bool isClear = false;
    private bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        stageControlScript = GameObject.Find("SampleStageController").GetComponent<StageControlScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsStun())
        {
            recoverTime -= Time.deltaTime;
        }
        else if (stageControlScript.state == StageControlScript.State.Play)
        {
            testMove();
        }
    }

    // 動作テスト用
    // 矢印キーでプレイヤーが移動
    public void testMove()
    {
        if (controller.isGrounded)
        {
            if (Input.GetAxis("Vertical") != 0.0f)
            {
                moveDirection.z = Input.GetAxis("Vertical") * speedRun;
            }
            if (Input.GetAxis("Horizontal") != 0.0f)
            {
                moveDirection.x = Input.GetAxis("Horizontal") * speedRun;
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;
        Vector3 globalDirection = transform.TransformDirection(moveDirection);
        controller.Move(globalDirection * Time.deltaTime);
        if (controller.isGrounded)
        {
            moveDirection.y = 0;
        }
    }

    // 気絶判定
    private bool IsStun()
    {
        return recoverTime > 0.0f;
    }

    public bool GetIsClear()
    {
        return isClear;
    }

    public bool GetIsGameOver()
    {
        return isGameOver;
    }

    // 衝突判定
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // 敵に当たったらライフを減らす
        // ライフがゼロになったらゲームオーバー
        if (hit.gameObject.tag == "enemy")
        {
            life -= 1;
            // 敵から一定距離をとり,気絶状態に入る
            string enemyName = hit.gameObject.name;
            Vector3 enemyPos = GameObject.Find(enemyName).transform.position;
            Vector3 playerPos = transform.position;
            playerPos.y = 0;
            enemyPos.y = 0;
            controller.Move(playerPos - enemyPos);
            recoverTime = StunDuration;

            Debug.Log("Life: " + life);
            if (life == 0)
            {
                isGameOver = true;
            }
        }
        // クリア可能な状態であればゲームクリアとする
        else if (hit.gameObject.tag == "goal")
        {
            if ((allowClear == true) && (Input.GetKeyDown(KeyCode.Space)))
            {
                isClear = true;
                // クリア時の処理を呼び出す
            }
        }
        // スペースキーでPiを取得
        else if (hit.gameObject.tag == "pi")
        {
            string piName = hit.gameObject.name;
            piControlScript = GameObject.Find(piName).GetComponent<PiControlScript>();
            if ((piControlScript.getIsValid() == true) && (Input.GetKeyDown(KeyCode.Space)))
            {
                pi += 1;
                piControlScript.setIsValid(false);
                // Pi取得時の関数を呼び出す
                Debug.Log("Pi: " + pi);
            }
            // Piを6個以上取得したらクリア可能状態にする
            if (pi == canClearPi)
            {
                allowClear = true;
            }
        }
        // ライフを回復
        else if (hit.gameObject.tag == "life")
        {
            if (life < maxLife)
            {
                life += 1;
            }
            Destroy(hit.gameObject);
            Debug.Log("Life: " + life);
        }
        // 落下したらゲームオーバーとする
        else if (hit.gameObject.tag == "abyss")
        {
            isGameOver = true;
        }
    }
}
