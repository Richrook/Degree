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
                case "ForestStage":
                    Debug.Log("Forest");
                    SceneManager.LoadScene("ForestStageScene");
                    break;
                case "DesertStage":
                    SceneManager.LoadScene("DesertStageScene");
                    break;
                case "WinterStage":
                    SceneManager.LoadScene("WinterStageScene");
                    break;
                case "DungeonStage":
                    SceneManager.LoadScene("DungeonStageScene");
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
