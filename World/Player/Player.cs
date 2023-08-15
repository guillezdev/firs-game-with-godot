using Godot;
using System;

public class Player : KinematicBody2D
{
    string name = "Nombre del jugador";
    float hp = 100;
    int damage = 10;
    bool live = true;
    float speed;
  

    public Vector2 distance = new Vector2(10, 10);

    public override void _Ready()
    {

        name = "Guillermo";
        hp = 100;
        damage = 10;
        live = true;
        speed = 100;

    }

    public override void _Process(float deltaTime)
    {
        distance.x = 0;
        if (Input.IsActionPressed("Right"))
        {
            distance.x += speed * deltaTime;
        }
        if (Input.IsActionPressed("Left"))
        {
            distance.x -= speed * deltaTime;
        }
        Position += distance;
    }
}
