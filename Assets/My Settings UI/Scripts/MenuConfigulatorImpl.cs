using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class MenuConfigulatorImpl {
    public enum UICompTypeName {
        toggle, inputField, slider, squareButton
    }

    public class MenuProperty {
        public UICompTypeName type;
        public string label;

        public Action callbackVoid;
        public Action<bool> callbackBool;
        public Action<string> callbackStr;
        public Action<float> callbackFloat;

        public bool initBool;
        public string initStr;
        public float initFloat, maxVal, minVal;

        public MenuProperty(UICompTypeName type, string label, Action callback) {
            this.type = type;
            this.label = label;
            this.callbackVoid = callback;
        }
        public MenuProperty(UICompTypeName type, string label, Action<bool> callback,
                            bool initVal = false) {
            this.type = type;
            this.label = label;
            this.callbackBool = callback;
            this.initBool = initVal;
        }
        public MenuProperty(UICompTypeName type, string label, Action<string> callback,
                            string initVal = "") {
            this.type = type;
            this.label = label;
            this.callbackStr = callback;
            this.initStr = initVal;
        }
        public MenuProperty(UICompTypeName type, string label, Action<float> callback,
                            float initVal = 50, float minVal = 0, float maxVal = 100) {
            this.type = type;
            this.label = label;
            this.callbackFloat = callback;
            this.initFloat = initVal;
            this.minVal = minVal;
            this.maxVal = maxVal;
        }

    }

    public MenuConfigulatorImpl() {
    }

    public List<MenuProperty> menuProperties = new List<MenuProperty>();

    public void Add(UICompTypeName type, string name, Action callback) {
        if (type != UICompTypeName.squareButton) {
            return;
        }
        menuProperties.Add(new MenuProperty(type, name, callback));
    }
    public void Add(UICompTypeName type, string name, Action<bool> callback,
                    bool initVal = false) {
        if (type != UICompTypeName.toggle) {
            return;
        }
        menuProperties.Add(new MenuProperty(type, name, callback, initVal));
    }
    public void Add(UICompTypeName type, string name, Action<string> callback,
                    string initVal = "") {
        if (type != UICompTypeName.inputField) {
            return;
        }
        menuProperties.Add(new MenuProperty(type, name, callback, initVal));
    }
    public void Add(UICompTypeName type, string name, Action<float> callback,
                    float initVal = 50, float minVal = 0, float maxVal = 100) {
        if (type != UICompTypeName.slider) {
            return;
        }
        menuProperties.Add(new MenuProperty(type, name, callback, initVal, minVal, maxVal));
    }

}


