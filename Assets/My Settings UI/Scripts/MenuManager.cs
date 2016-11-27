using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class MenuManager : MonoBehaviour {

    public GameObject menuBase;
    public UnityEngine.UI.Toggle toggle;
    public UnityEngine.UI.InputField inputField;
    public UnityEngine.UI.Slider slider;
    public UnityEngine.UI.Button squareButton;
    public Vector2 offset = new Vector2(0, -40);
    public Vector2 pos = new Vector2(50, 0);

    private List<IMyUICompManager> uiCompMgrs = new List<IMyUICompManager>();
    private MenuConfigulator menuConfig;

    void Start() {
        menuConfig = GetComponent<MenuConfigulator>();
        menuConfig.setup();
        initialize();
        placeComps();
    }

    private void initialize() {
        foreach (var property in menuConfig.menuProperties) {
            if (MenuConfigulatorImpl.UICompTypeName.toggle == property.type) {
                uiCompMgrs.Add(new MyToggleManager(Instantiate(toggle), menuBase.transform,
                                                   property.label, Action2UnityAction(property.callbackBool),
                                                   property.initBool));
            } else if (MenuConfigulatorImpl.UICompTypeName.inputField == property.type) {
                uiCompMgrs.Add(new MyInputFieldManager(Instantiate(inputField), menuBase.transform,
                                                       property.label, Action2UnityAction(property.callbackStr),
                                                       MyInputFieldManager.Empty,
                                                       property.initStr));
            } else if (MenuConfigulatorImpl.UICompTypeName.slider == property.type) {
                uiCompMgrs.Add(new MySliderManager(Instantiate(slider), menuBase.transform,
                                                   property.label, Action2UnityAction(property.callbackFloat),
                                                   property.initFloat, property.minVal, property.maxVal));

            } else if (MenuConfigulatorImpl.UICompTypeName.squareButton == property.type) {
                uiCompMgrs.Add(new MyButtonManager(Instantiate(squareButton), menuBase.transform,
                                                   property.label, Action2UnityAction(property.callbackVoid)));
            }
        }
    }

    private void placeComps() {
        foreach (var uiCompMgr in uiCompMgrs) {
            pos += offset;
            uiCompMgr.AddComponent(pos);
        }
        var baseRectTF = menuBase.GetComponent<RectTransform>();
        baseRectTF.sizeDelta = new Vector2(0, Mathf.Max(Mathf.Abs(pos.y + offset.y), baseRectTF.sizeDelta.y));
    }



    static private UnityEngine.Events.UnityAction Action2UnityAction(Action action) {
        return new UnityEngine.Events.UnityAction(() => {
            action();
        });
    }

    static private UnityEngine.Events.UnityAction<T> Action2UnityAction<T> (Action<T> action) {
        return new UnityEngine.Events.UnityAction<T>((T arg) => {
            action(arg);
        });
    }

}
