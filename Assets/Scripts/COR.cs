using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class COR : MonoBehaviour {
    [SerializeField] float time = 0.1f;
    [SerializeField] bool go = false;

    Coroutine timerCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        timerCoroutine = StartCoroutine(Timer(time));
        StartCoroutine(StoryTime());
        StartCoroutine(WaitAction());
    }

    // Update is called once per frame
    void Update()
    {
        //time -= Time.deltaTime;
        //if (time <= 0) {
        //    time = 3;
        //    print("hello");
        //}
    }

    IEnumerator Timer(float time) {
        while (true) {
            yield return new WaitForSeconds(time);
            //check perception
            print("Tick");
        }
        //yield return null;
    }

    IEnumerator StoryTime() {
        print("Hello");
        yield return new WaitForSeconds(1);
        print("Welcome to the new world");
        yield return new WaitForSeconds(1);
        print("Time to Die");
        yield return new WaitForSeconds(1);

        StopCoroutine(timerCoroutine);

        yield return null;
    }

    IEnumerator WaitAction() {
        yield return new WaitUntil(() => go);
        print("go");
        yield return null;
    }
}
