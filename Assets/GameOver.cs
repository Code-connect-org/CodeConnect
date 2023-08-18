using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable() {
        StartCoroutine(Gameover());
    }
    public IEnumerator Gameover(){
        for(float t = 0;t < 1;t += Time.deltaTime){
            Time.timeScale = 1-t/2;
            yield return null;
        }
        yield return new WaitForSeconds(1);
            Time.timeScale = 1;
        SceneManager.LoadScene("title");
        yield break;
    }
}
