using Microsoft.Xna.Framework.Input;

namespace Chess2000.Controls;

public class MouseTools
{
    public enum MouseButton
    {
        Left = 0,
        Right = 1
    };

    private bool _leftButtonPressed;
    private bool _rightButtonPressed;

    public bool IsButtonPressed(MouseButton button)
    {
        MouseState mouseState = Mouse.GetState();
        if (!_leftButtonPressed && mouseState.LeftButton == ButtonState.Pressed)
        {
            _leftButtonPressed = true;
            return true;
        }
        else if (_leftButtonPressed && mouseState.LeftButton == ButtonState.Pressed)
        {
            return false;
        }
        else if (_leftButtonPressed && mouseState.LeftButton == ButtonState.Released)
        {
            _leftButtonPressed = false;
            return false;
        }

        return _leftButtonPressed;
    }
}