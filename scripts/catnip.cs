using Godot;
using System;

public partial class catnip : RigidBody2D
{
	[Export] public Texture2D highCatTexture;
	[Export] public float highModifier = 2f;
	public bool IsHigh {get; set;}
	private joints cat;

	public override void _Ready()
	{
		cat = GetNode("../joints") as joints;
		IsHigh = false;
	}


	public void _OnBodyEntered(Node body) {
		if (body.Name == "catnip" && !IsHigh) {
			IsHigh = true;
			cat.stabilizationForce = 0f;
			cat.jointStabilizationForce = 0f;
			cat.forceStrength *= highModifier;
			cat.groundRaycast.TargetPosition = new Vector2(0, cat.groundRaycast.TargetPosition.Y * 2f);
		}
	}
}
