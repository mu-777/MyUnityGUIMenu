using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShowMenu : MonoBehaviour {

    public List<GameObject> menuUis;
    public KeyCode menuTriggerKey = KeyCode.O;
    private bool isMenuActive = false;

    void Awake() {
        foreach (var menu in menuUis) {
            menu.SetActive(isMenuActive);
        }
    }

    void Update() {
        if (Input.GetKeyDown(menuTriggerKey)) {
            isMenuActive = !isMenuActive;
            foreach (var menu in menuUis) {
                menu.SetActive(isMenuActive);
            }
        }
    }


}
