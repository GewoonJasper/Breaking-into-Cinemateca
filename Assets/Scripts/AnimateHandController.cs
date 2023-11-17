using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator))]
public class AnimateHandController : MonoBehaviour
{
    public InputActionReference GripActionReference;
    public InputActionReference TriggerActionReference;

    private Animator _handAnimator;
    private float _gripValue;
    private float _triggerValue;

    // Start is called before the first frame update
    void Start()
    {
        _handAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimateGrip();
        AnimateTrigger();
    }

    public void AnimateGrip()
    {
        _gripValue = GripActionReference.action.ReadValue<float>();
        _handAnimator.SetFloat("Grip", _gripValue);
    }

    public void AnimateTrigger()
    {
        _triggerValue = TriggerActionReference.action.ReadValue<float>();
        _handAnimator.SetFloat("Trigger", _triggerValue);
    }
}
