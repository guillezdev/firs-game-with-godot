using Godot;
using System;

public class Player : KinematicBody2D
{
    string name = "Nombre del jugador";
    float hp = 100;
    int damage = 10;
    bool live = true;
    float defaultSpeed;
    float currentSpeed;
    float jumpH;

    const float gravity = 2000;

    public AnimatedSprite _animatedSprite;

    public Vector2 velocity = new Vector2(10, 10);



    public override void _Ready()
    {

        name = "Guillermo";
        hp = 100;
        damage = 10;
        live = true;
        defaultSpeed = 200;
        currentSpeed = 400;
        jumpH = 130;

        _animatedSprite = GetNode<AnimatedSprite>("AnimatedSprite");


    }


    public override void _PhysicsProcess(float deltaTime)
    {

        PlayerAction(deltaTime);

    }

    public void PlayerAction(float deltaTime)
    {
        velocity.x = 0;



        if (Input.IsActionJustPressed("Run"))
        {
            defaultSpeed = currentSpeed;
            _animatedSprite.Frames.SetAnimationSpeed("runing", 30);
        }

        if (Input.IsActionJustReleased("Run"))
        {
            defaultSpeed = 200;
            _animatedSprite.Frames.SetAnimationSpeed("runing", 18);
        }


        if (Input.IsActionPressed("Right"))
        {
            velocity.x += defaultSpeed;
            _animatedSprite.Play("runing");
            _animatedSprite.FlipH = false;
        }
        else if (Input.IsActionPressed("Left"))
        {
            velocity.x -= defaultSpeed;
            _animatedSprite.Play("runing");
            _animatedSprite.FlipH = true;
        }
        else
        {
            _animatedSprite.Play("idle");
        }


        MoveAndSlide(velocity, Vector2.Up);

        velocity.y += gravity * deltaTime;

        if (IsOnFloor())
        {
            velocity.y = 0;

            if (Input.IsActionPressed("Jump"))
            {
                velocity.y = -(float)Math.Sqrt(2 * gravity * jumpH);
            }

        }


    }

}
