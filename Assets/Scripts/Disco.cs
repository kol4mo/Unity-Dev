using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Disco : MonoBehaviour
{
    [SerializeField] Light DiscoLight;
    [SerializeField] float timerLength;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        time = timerLength;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time < 0) {
            DiscoLight.color = Color.HSVToRGB(Random.Range(0, 1.0f), 1.0f, 1.0f);
            time = timerLength;
        }
    }
}
