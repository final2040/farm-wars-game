using System;
using UnityEngine;

[Serializable]
public struct Controls
{
    [SerializeField] private string horizontalAxis;
    [SerializeField] private string verticalAxis;
    [SerializeField] private KeyCode attack;
    [SerializeField] private KeyCode pause;

    public string HorizontalAxis => horizontalAxis;

    public string VerticalAxis => verticalAxis;

    public KeyCode Attack => attack;
    public KeyCode Pause => pause;
}