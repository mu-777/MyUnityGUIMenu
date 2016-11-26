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
        foreach (var pair in menuConfig.typeMap) {
            if (MenuConfigulatorImpl.UICompTyoeName.toggle == pair.Value) {
                uiCompMgrs.Add(new MyToggleManager(Instantiate(toggle), menuBase.transform,
                                                   pair.Key, Action2UnityAction(menuConfig.actionBoolMap[pair.Key])));
            } else if (MenuConfigulatorImpl.UICompTyoeName.inputField == pair.Value) {
                uiCompMgrs.Add(new MyInputFieldManager(Instantiate(inputField), menuBase.transform,
                                                       pair.Key, Action2UnityAction(menuConfig.actionStringMap[pair.Key]),
                                                       MyInputFieldManager.Empty));
            } else if (MenuConfigulatorImpl.UICompTyoeName.slider == pair.Value) {
                uiCompMgrs.Add(new MySliderManager(Instantiate(slider), menuBase.transform,
                                                   pair.Key, Action2UnityAction(menuConfig.actionFloatMap[pair.Key])));

            } else if (MenuConfigulatorImpl.UICompTyoeName.squareButton == pair.Value) {
                uiCompMgrs.Add(new MyButtonManager(Instantiate(squareButton), menuBase.transform,
                                                   pair.Key, Action2UnityAction(menuConfig.actionVoidMap[pair.Key])));
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
