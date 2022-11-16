using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CustomUIElementCreator : MonoBehaviour
{

    // Start is called before the first frame update
    [MenuItem("GameObject/UI/Ui_Button")]
    public static void AddButton()
    {
        GameObject uiButton = Instantiate(AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Button.prefab"));
        uiButton.transform.SetParent(Selection.activeTransform, false);
        uiButton.name = "Button";
    }
    [MenuItem("GameObject/UI/Ui_Toggle")]
    public static void AddToggle()
    {
        GameObject uiToggle = Instantiate(AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Toggle.prefab"));
        uiToggle.transform.SetParent(Selection.activeTransform, false);
        uiToggle.name = "Toggle";
    }
}
