using Godot;
using System;

public class GameEvents : Node
{
    [Signal]
    public delegate int ScoreChanged(int value);
    public override void _Ready()
    {
        
    }
}
