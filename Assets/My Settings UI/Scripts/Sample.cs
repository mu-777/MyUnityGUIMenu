using UnityEngine;
using System.Collections;

public class Sample : MonoBehaviour {

    public void changeScale(float scale) {
        this.transform.localScale = Vector3.one * scale;
    }


}
