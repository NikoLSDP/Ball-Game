using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    [SerializeField]
    private Text timer;
    [SerializeField]
    private float lvlTimer;
    private float time;
    private bool TimerAct;
	void Start () {
        TimerAct = false;
        time = lvlTimer;
	}
	
	// Update is called once per frame
	void Update () {
        timer.text = "Timer: " + (int)time;
        if (TimerAct)
            time -= 0.7f * Time.deltaTime;

        if (Input.anyKeyDown && !TimerAct && GameManager.Instance.Playing)
            TimerAct = true;
	}
}
