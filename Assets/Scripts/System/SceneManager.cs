using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public GameObject logoImage; // UI ImageにアタッチしたGameObject

    private void Start()
    {
        logoImage.SetActive(true); // ロゴを表示
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            LoadGameScene();
        }
    }

    private void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene"); // ゲームのメインシーン名に変更
    }
}