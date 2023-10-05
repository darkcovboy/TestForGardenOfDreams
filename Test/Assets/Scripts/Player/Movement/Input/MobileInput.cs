using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileInput : IInput
{
    //Имеют одинаковую реализацию как для компа, так и для мобилок, но в случае портирования(условно) можно будет 
    //добавить сюда реализацию для управления с клавиатуры, это пока заготовка на будущее
    public Vector2 GetInputDirection()
    {
        float horizontalInput = SimpleInput.GetAxis(UsefulConstants.HorizontalAxis);
        Vector2 moveDirection = new Vector2(horizontalInput, 0f).normalized;
        return moveDirection;
    }
}
