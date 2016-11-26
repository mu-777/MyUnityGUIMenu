using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class MenuConfigulator {
    public enum UICompTyoeName {
        toggle, inputField, slider, squareButton
    }

    public MenuConfigulator() {
        add(UICompTyoeName.toggle, "toggleName", (bool flag) => {
            MonoBehaviour.print("toggle: " + flag);
        });
        add(UICompTyoeName.inputField, "inputFieldName", (string str) => {
            MonoBehaviour.print("inputField: " + str);
        });
        add(UICompTyoeName.slider, "sliderName", (float val) => {
            MonoBehaviour.print("slider: " + val);
        });
        add(UICompTyoeName.squareButton, "sqButtonName", () => {
            MonoBehaviour.print("sqButton: clicked!");
        });
    }

    public Dictionary<string, UICompTyoeName> typeMap = new Dictionary<string, UICompTyoeName>();
    public Dictionary<string, Action> actionVoidMap = new Dictionary<string, Action>();
    public Dictionary<string, Action<bool>> actionBoolMap = new Dictionary<string, Action<bool>>();
    public Dictionary<string, Action<string>> actionStringMap = new Dictionary<string, Action<string>>();
    public Dictionary<string, Action<float>> actionFloatMap = new Dictionary<string, Action<float>>();

    private void add(UICompTyoeName type, string name, Action callback) {
        if (type != UICompTyoeName.squareButton) {
            return;
        }
        typeMap.Add(name, type);
        actionVoidMap.Add(name, callback);
    }
    private void add(UICompTyoeName type, string name, Action<bool> callback) {
        if (type != UICompTyoeName.toggle) {
            return;
        }
        typeMap.Add(name, type);
        actionBoolMap.Add(name, callback);
    }
    private void add(UICompTyoeName type, string name, Action<string> callback) {
        if (type != UICompTyoeName.inputField) {
            return;
        }
        typeMap.Add(name, type);
        actionStringMap.Add(name, callback);
    }
    private void add(UICompTyoeName type, string name, Action<float> callback) {
        if (type != UICompTyoeName.slider) {
            return;
        }
        typeMap.Add(name, type);
        actionFloatMap.Add(name, callback);
    }

}


