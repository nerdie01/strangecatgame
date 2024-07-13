using Godot;
using System;

public partial class joints : Node2D
{
	[Export] public float stabilizationForce = 100f;
	[Export] public float spinnyLegSpeed = 100f;
	private RigidBody2D bodyReference;
	private RigidBody2D[] bodyParts = new RigidBody2D[3];
	private PinJoint2D[] pinJoints = new PinJoint2D[3];

	public override void _Ready()
	{
		bodyReference = GetNode("../body") as RigidBody2D;
		bodyParts[0] = GetNode("../head") as RigidBody2D;
		bodyParts[1] = GetNode("../leg_1") as RigidBody2D;
		bodyParts[2] = GetNode("../leg_2") as RigidBody2D;
		pinJoints[0] = GetNode("joint_head") as PinJoint2D;
		pinJoints[1] = GetNode("joint_leg_1") as PinJoint2D;
		pinJoints[2] = GetNode("joint_leg_2") as PinJoint2D;
	}

    public override void _PhysicsProcess(double delta)
    {
		pinJoints[0].MotorTargetVelocity = -bodyParts[0].Rotation * stabilizationForce;
		
		if (Input.IsActionPressed("right")) {
			pinJoints[1].MotorTargetVelocity = spinnyLegSpeed;
			pinJoints[2].MotorTargetVelocity = spinnyLegSpeed;
		}
		else if (Input.IsActionPressed("left")) {
			pinJoints[1].MotorTargetVelocity = -spinnyLegSpeed;
			pinJoints[2].MotorTargetVelocity = -spinnyLegSpeed;
		}
		else {
			pinJoints[1].MotorTargetVelocity = -bodyParts[1].Rotation * stabilizationForce;
			pinJoints[2].MotorTargetVelocity = -bodyParts[2].Rotation * stabilizationForce;
		}
    }
}
