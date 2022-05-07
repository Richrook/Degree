using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSelectSceneScript : MonoBehaviour
{
    // 衝突判定
    void OnCollisionStay(Collision collision)
    {
        if(Input.GetKeyDown(KeyCode.Return)){
            switch(collision.gameObject.name)
            {
                // 各ステージを追加したらコメントアウトを外してください.
                case "ForestStage":
                    Debug.Log("To Forest");
                    //SceneManager.LoadScene("ForestStageScene");
                    break;
                case "DesertStage":
                    Debug.Log("To Desert");
                    //SceneManager.LoadScene("DesertStageScene");
                    break;
                case "WinterStage":
                    Debug.Log("To Winter");
                    //SceneManager.LoadScene("WinterStageScene");
                    break;
                case "DungeonStage":
                    Debug.Log("To Dungeon");
                    //SceneManager.LoadScene("DungeonStageScene");
                    break;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // 落下したら再読み込み
        if (collision.gameObject.tag == "abyss")
        {
            Debug.Log("Abyss");
            SceneManager.LoadScene (SceneManager.GetActiveScene().name);
        }
    }
}
