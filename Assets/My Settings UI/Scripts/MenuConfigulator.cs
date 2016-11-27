using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class MenuConfigulator : MonoBehaviour {

    private MenuConfigulatorImpl menuConfig = new MenuConfigulatorImpl();

    public Sample target;

    public void setup() {
        menuConfig.Add(MenuConfigulatorImpl.UICompTypeName.toggle,
                       "is visible", target.gameObject.SetActive,
                       true);
        menuConfig.Add(MenuConfigulatorImpl.UICompTypeName.slider,
                       "scale controller", target.changeScale,
                       1, 0, 10);
        //setupSample();
    }

    private void setupSample() {
        menuConfig.Add(MenuConfigulatorImpl.UICompTypeName.toggle,
                       "toggleName", toggleCallbackSample);
        menuConfig.Add(MenuConfigulatorImpl.UICompTypeName.inputField,
                       "inputFieldName", inputFieldCallbackSample);
        menuConfig.Add(MenuConfigulatorImpl.UICompTypeName.slider,
                       "sliderName", sliderCallbackSample);
        menuConfig.Add(MenuConfigulatorImpl.UICompTypeName.squareButton,
                       "sqButtonName", buttonCallbackSample);
    }

    private Action<bool> toggleCallbackSample = (bool flag) => {
        MonoBehaviour.print("toggle: " + flag);
    };

    private Action<string> inputFieldCallbackSample = (string str) => {
        MonoBehaviour.print("inputField: " + str);
    };

    private Action<float> sliderCallbackSample = (float val) => {
        MonoBehaviour.print("slider: " + val);
    };

    private Action buttonCallbackSample = () => {
        MonoBehaviour.print("sqButton: clicked!");
    };

    public List<MenuConfigulatorImpl.MenuProperty> menuProperties { get { return menuConfig.menuProperties; } }
}
