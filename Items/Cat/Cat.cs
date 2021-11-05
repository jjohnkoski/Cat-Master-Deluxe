using Godot;
using System;

public class Cat : Area2D
{
    public const int ScoreValue = 1;
    public override void _Ready()
    {
        AnimatedSprite sprite = GetNode<AnimatedSprite>("AnimatedSprite");
        sprite.Play("purr");
    }

    public void _on_Cat_body_entered(PhysicsBody2D body)
    {
        GameEvents gameEvents = GetNode<GameEvents>("/root/GameEvents");
        AnimatedSprite sprite = GetNode<AnimatedSprite>("AnimatedSprite");
        AudioStreamPlayer2D sound = GetNode<AudioStreamPlayer2D>("AudioStreamPlayer2D");
        sprite.Play("pickup");
        sound.Play();
        gameEvents.EmitSignal("ScoreChanged", ScoreValue);
    }

    public void _on_AudioStreamPlayer2D_finished()
    {
        QueueFree();
    }
}
