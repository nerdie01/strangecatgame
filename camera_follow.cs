using Godot;
using System;
using System.Runtime;
using System.Security.Cryptography.X509Certificates;

public partial class camera_follow : Camera2D
{
	[Export] public double lerpSpeed = 3.0;
	private RigidBody2D cat;
	private Vector2 offset;
	
	public override void _Ready()
	{
		cat = GetNode("../cat/body") as RigidBody2D;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		GlobalTransform = GlobalTransform.InterpolateWith(cat.GlobalTransform.TranslatedLocal(offset), (float)(lerpSpeed * delta));
	}
}
