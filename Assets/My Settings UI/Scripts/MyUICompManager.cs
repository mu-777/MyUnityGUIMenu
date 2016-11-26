using UnityEngine;
using System;
using System.Collections;


public interface IMyUICompManager {
    void AddComponent(Vector2 pos);
    float GetWidth();
    float GetHeight();
}

public abstract class MyUICompManagerBase : IMyUICompManager {
    protected GameObject uiComp;
    protected RectTransform rectTF;
    private string labelObjectName = "Label";

    public MyUICompManagerBase(GameObject uiComp, Transform parent, string label) {
        this.uiComp = uiComp;
        this.uiComp.transform.parent = parent;
        this.rectTF = this.uiComp.GetComponent<UnityEngine.RectTransform>();
        this.rectTF.anchorMax = new Vector2(0, 1);
        this.rectTF.anchorMin = new Vector2(0, 1);
        this.rectTF.pivot = new Vector2(0, 0);

        foreach (var textComp in this.uiComp.GetComponentsInChildren<UnityEngine.UI.Text>()) {
            if (textComp.name == labelObjectName) {
                textComp.text = label;
            }
        }
        this.uiComp.name = label;
    }

    public float GetWidth() {
        return rectTF.sizeDelta.x;
    }

    public float GetHeight() {
        return rectTF.sizeDelta.y;
    }

    public void AddComponent(Vector2 pos) {
        this.rectTF.anchoredPosition = pos;
    }
}

public class MyToggleManager : MyUICompManagerBase {
    public static UnityEngine.Events.UnityAction<bool> Empty = (flag) => { };

    public MyToggleManager(UnityEngine.UI.Toggle toggle, Transform parent, string label,
                           UnityEngine.Events.UnityAction<bool> onValueChanged)
        : base(toggle.gameObject, parent, label) {
        toggle.onValueChanged.AddListener(onValueChanged);
    }
}

public class MyInputFieldManager : MyUICompManagerBase {
    public static UnityEngine.Events.UnityAction<string> Empty = (str) => { };

    public MyInputFieldManager(UnityEngine.UI.InputField inputField, Transform parent, string label,
                               UnityEngine.Events.UnityAction<string> onEndEdit,
                               UnityEngine.Events.UnityAction<string> onValueChanged)
        : base(inputField.gameObject, parent, label) {
        inputField.onEndEdit.AddListener(onEndEdit);
        inputField.onValueChanged.AddListener(onValueChanged);
    }
}

public class MySliderManager : MyUICompManagerBase {
    public static UnityEngine.Events.UnityAction<float> Empty = (single) => { };

    public MySliderManager(UnityEngine.UI.Slider slider, Transform parent, string label,
                           UnityEngine.Events.UnityAction<float> onValueChanged)
        : base(slider.gameObject, parent, label) {
        slider.onValueChanged.AddListener(onValueChanged);
    }
}

public class MyButtonManager : MyUICompManagerBase {
    public static UnityEngine.Events.UnityAction Empty = () => { };

    public MyButtonManager(UnityEngine.UI.Button button, Transform parent, string label,
                           UnityEngine.Events.UnityAction onClick)
        : base(button.gameObject, parent, label) {
        button.onClick.AddListener(onClick);
    }
}
