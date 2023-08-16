using Godot;
using System;

public class Player : KinematicBody2D
{
    string name = "Nombre del jugador";
    float hp = 100;
    int damage = 10;
    bool live = true;
    float speed;
    float jumpH;

    const float gravity = 2000;

    public Vector2 velocity = new Vector2(10, 10);


    public override void _Ready()
    {

        name = "Guillermo";
        hp = 100;
        damage = 10;
        live = true;
        speed = 200;
        jumpH = 130;


    }

    public override void _Process(float deltaTime)
    {

    }
    public override void _PhysicsProcess(float deltaTime)
    {

        PlayerAction(deltaTime);

    }

    public void PlayerAction(float deltaTime)
    {
        velocity.x = 0;


        velocity.y += gravity * deltaTime;

        if (Input.IsActionPressed("Right"))
        {
            velocity.x += speed;
        }
        if (Input.IsActionPressed("Left"))
        {
            velocity.x -= speed;
        }

        MoveAndSlide(velocity, Vector2.Up);



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
