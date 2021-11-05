using Godot;
using System;

public class HUD : Control
{
    public int score = 0;
    public override void _Ready()
    {
        Label scoreLabel = GetNode<Label>("MarginContainer/VBoxContainer/HBoxContainer/ScoreLabel");
        scoreLabel.Text = $"CATS: {score}";
    }

    public void _enter_tree()
    {
        GameEvents gameEvents = GetNode<GameEvents>("/root/GameEvents");
        gameEvents.Connect("ScoreChanged", this, "OnScoreChanged");
    }

    public void _exit_tree()
    {
        GameEvents gameEvents = GetNode<GameEvents>("/root/GameEvents");
        gameEvents.Disconnect("ScoreChanged", this, "OnScoreChanged");
    }

    public void OnScoreChanged(int receivedScore)
    {
        score += receivedScore;
        Label scoreLabel = GetNode<Label>("MarginContainer/VBoxContainer/HBoxContainer/ScoreLabel");
        scoreLabel.Text = $"CATS: {score}";
    }
}
