using Godot;
using System;
using System.Data.Common;

public partial class stabilizecat : RigidBody2D
{
    public override void _PhysicsProcess(double delta)
    {
		GD.Print(-GlobalRotation * MathF.PI/180);
        AddConstantTorque(-GlobalRotation);
    }
}
