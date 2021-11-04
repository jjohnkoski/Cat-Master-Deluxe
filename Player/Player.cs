using Godot;
using System;

public class Player : KinematicBody2D
{
    [Export]
    public int Speed = 100;
    [Export]
    public int Gravity = 2000;

    private Vector2 _velocity = Vector2.Zero;

    public override void _Ready()
    {
        
    }

    public override void _Process(float delta)
    {
        var sprite = GetNode<AnimatedSprite>("AnimatedSprite");
        _velocity.x = 0;

        if (Input.IsActionPressed("ui_right"))
		{
			_velocity.x += Speed;
		}
		if (Input.IsActionPressed("ui_left"))
		{
			_velocity.x -= Speed;
		}

        _velocity.y += Gravity * delta;
        _velocity = MoveAndSlide(_velocity, Vector2.Up);

        if (_velocity.x != 0)
        {
            sprite.Animation = "walk";
            sprite.FlipV = false;
            sprite.FlipH = _velocity.x < 0;
            sprite.Play("walk");
        }
        else if (_velocity.y != 0)
        {
            sprite.Play("jump");
        }
        else
        {
            sprite.Play("idle");
        }
    }
}
