using Godot;
using System;

public partial class joints : Node2D
{
	private RigidBody2D bodyReference;
	private RigidBody2D[] bodyParts = new RigidBody2D[3];
	private PinJoint2D[] pinJoints = new PinJoint2D[3];

	public override void _Ready()
	{
		bodyReference = GetNode("../body") as RigidBody2D;
		bodyParts[0] = GetNode("../meower") as RigidBody2D;
		bodyParts[1] = GetNode("../leg") as RigidBody2D;
		bodyParts[2] = GetNode("../leg2") as RigidBody2D;
		pinJoints[0] = GetNode("meowerbody") as PinJoint2D;
		pinJoints[1] = GetNode("bodyleg1") as PinJoint2D;
		pinJoints[2] = GetNode("bodyleg2") as PinJoint2D;
	}

    public override void _PhysicsProcess(double delta)
    {
		for (int i = 0; i < bodyParts.Length; i++) {
			// GD.Print(i, bodyParts[i].Rotation * 1000f);
			pinJoints[i].MotorTargetVelocity = bodyParts[i].Rotation * 1000f;
		}
    }
}
