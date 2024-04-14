using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Tester : MonoBehaviour
{
    private bool _isShow;


    private VisualElement _container;

    private Button _button;
    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        _container = root.Q<VisualElement>("ModalWindow");

        _button = root.Q<Button>("PlayButton");

        _button.RegisterCallback<ClickEvent>(OnOpenButtonClicked);
    }

    private void OnOpenButtonClicked(ClickEvent evt)
    {  
        if(_container.ClassListContains("rightWindow"))
            _container.RemoveFromClassList("rightWindow");
        else
            _container.AddToClassList("rightWindow");
    }

    
}
