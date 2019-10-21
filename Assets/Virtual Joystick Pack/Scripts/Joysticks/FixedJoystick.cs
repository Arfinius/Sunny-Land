using UnityEngine;
using UnityEngine.EventSystems;

public class FixedJoystick : Joystick
{
    Vector2 joystickPosition = Vector2.zero;

    private Camera cam = new Camera();

    void Start()
    {
        joystickPosition = RectTransformUtility.WorldToScreenPoint(cam, background.position);

    }

    public void Clicked()
    {
        
        Touch touch = Input.GetTouch(0);
        
        Vector2 direction = touch.position - joystickPosition;
        inputVector = (direction.magnitude > background.sizeDelta.x / 2f) ? direction.normalized : direction / (background.sizeDelta.x / 2f);
        ClampJoystick();
        handle.anchoredPosition = (inputVector * background.sizeDelta.x / 2f) * handleLimit;
    }

    public void UnClicked()
    {
        inputVector = Vector2.zero;
        handle.anchoredPosition = Vector2.zero;
        ClampJoystick();
    }

    public void OnClick()
    {
        Touch touch = Input.GetTouch(0);
        joystickPosition = touch.position;
    }
}