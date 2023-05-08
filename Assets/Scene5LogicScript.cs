using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene5LogicScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("NextScene", GameSystem.sceneLength);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void NextScene()
    {
        SceneManager.LoadScene("Scene 6");
    }
}
