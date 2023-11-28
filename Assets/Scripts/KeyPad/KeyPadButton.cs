using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Filtering;

public class KeyPadButton : XRSimpleInteractable
{
    enum ButtonType
    {
        Number,
        Cancel,
        Enter
    }

    [SerializeField] 
    private KeyPadControl _keyPadControl;

    private ButtonType _buttonType;
    private int _number;

    // Start is called before the first frame update
    void Start()
    {
        var name = this.name;

        name = name.Replace("Cube ", "");

        //There is probably a better way to do this
        try
        {
            _number = int.Parse(name);
            _buttonType = ButtonType.Number;
        }
        catch
        {
            if (name.Equals("Check")) _buttonType = ButtonType.Enter;
            else if (name.Equals("Cancel")) _buttonType = ButtonType.Cancel;
        }
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        //base.OnSelectEntered(args);
        switch (_buttonType)
        {
            case ButtonType.Number:
                _keyPadControl.AddNumber(_number);
                break;
            case ButtonType.Cancel:
                _keyPadControl.Cancel();
                break;
            case ButtonType.Enter:
                _keyPadControl.CheckCode();
                break;
        }
    }
}
