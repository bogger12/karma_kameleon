using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLogicScript : MonoBehaviour
{
    float timer = GameSystem.sceneLength;
    //public string nextSceneName = "Scene 2";

    public GameObject[] scenes;

    public GameObject currentscene;

    public int sceneNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().speed = GameSystem.animspeed;
        //Invoke("NextScene", GameSystem.sceneLength);
        NextScene();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) SceneManager.LoadScene("TitleScreen");
        if (timer <= 0f) {
            timer = GameSystem.sceneLength;
            NextScene();
            return;
        }
        else {
            timer -= Time.deltaTime;
        }


    }
    void NextScene()
    {
        sceneNum++;
        if (sceneNum > 6) SceneManager.LoadScene("TitleScreen");
        Debug.Log("Scene Change");
        Debug.Log(sceneNum);

        currentscene.SetActive(false);
        scenes[sceneNum-1].SetActive(true);
        currentscene = scenes[sceneNum - 1];

        //SceneManager.LoadScene(nextSceneName);
    }
}
