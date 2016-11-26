using UnityEngine;
using System.Collections;

public class Sample : MonoBehaviour {

    Vector3 defaultScale;
    // Use this for initialization
    void Start() {
        defaultScale = this.transform.localScale;

    }

    public void changeScale(float rate) {
        this.transform.localScale = defaultScale * (rate / 50.0f);
    }

    public void changeColor(string color) {

    }

}
