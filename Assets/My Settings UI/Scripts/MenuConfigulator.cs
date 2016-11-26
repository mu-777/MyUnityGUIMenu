using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class MenuConfigulator : MonoBehaviour {

    private MenuConfigulatorImpl menuConfig = new MenuConfigulatorImpl();

    public Sample target;

    public void setup() {
        menuConfig.add(MenuConfigulatorImpl.UICompTyoeName.toggle,
                       "is visible", target.gameObject.SetActive);
        menuConfig.add(MenuConfigulatorImpl.UICompTyoeName.slider,
                       "scale controller", target.changeScale);
        //setupSample();
    }

    private void setupSample() {
        menuConfig.add(MenuConfigulatorImpl.UICompTyoeName.toggle,
                       "toggleName", toggleCallbackSample);
        menuConfig.add(MenuConfigulatorImpl.UICompTyoeName.inputField,
                       "inputFieldName", inputFieldCallbackSample);
        menuConfig.add(MenuConfigulatorImpl.UICompTyoeName.slider,
                       "sliderName", sliderCallbackSample);
        menuConfig.add(MenuConfigulatorImpl.UICompTyoeName.squareButton,
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

    public Dictionary<string, MenuConfigulatorImpl.UICompTyoeName> typeMap { get { return menuConfig.typeMap; } }
    public Dictionary<string, Action> actionVoidMap { get { return menuConfig.actionVoidMap; } }
    public Dictionary<string, Action<bool>> actionBoolMap { get { return menuConfig.actionBoolMap; } }
                                         public Dictionary<string, Action<string>> actionStringMap { get { return menuConfig.actionStringMap; } }
                                         public Dictionary<string, Action<float>> actionFloatMap { get { return menuConfig.actionFloatMap; } }

}
