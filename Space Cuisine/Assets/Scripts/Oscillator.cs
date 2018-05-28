using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour {

    [SerializeField] Vector3 movementVector = new Vector3(10f, 10f, 10f);
    [SerializeField] float period = 2f; // defualt at 2 seconds

    Vector3 startingPos;
    float movementFactor;

	// Use this for initialization
	void Start () {
        startingPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (period <= Mathf.Epsilon) return;
        float cycles = Time.time/ period;
        const float tau = Mathf.PI * 2;
        float rawSinWave = Mathf.Sin(cycles * tau); // goes from minus 1 to plus 1
        movementFactor = rawSinWave / 2f + 0.5f; // as we want 1f not 0,5;



        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPos + offset;
	}
}
