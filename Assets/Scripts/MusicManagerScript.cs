using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManagerScript : MonoBehaviour {
    public AudioSource mainMusic;
    public AudioSource monsterTheme;
    public double monkeyXPos;
    public double monkeyClosenessFactor;
    public int musicKickInLimit = 8; //higher value means monster theme will kick in at a further distance from monkey

    public float mainvolume;
    void Start() {
        mainvolume = mainMusic.volume;
        monsterTheme.volume = 0;
        mainMusic.Play();
        monsterTheme.Play();
    }

    void Update() {
        if (GameSystem.gameIsOver) {
            mainMusic.Stop();
            monsterTheme.Stop();
        } else {
            monkeyXPos = GameObject.FindGameObjectWithTag("Monkey").transform.position.x;
            if (monkeyXPos > -musicKickInLimit) {
                monkeyClosenessFactor = 1 - monkeyXPos/-musicKickInLimit;
            } else {
                monkeyClosenessFactor = 0;
            }
            mainMusic.volume = (1 - (float)monkeyClosenessFactor) * mainvolume;
            monsterTheme.volume = (float)monkeyClosenessFactor * mainvolume;
        }
    }
}