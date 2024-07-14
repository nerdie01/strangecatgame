using Godot;
using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Security.Cryptography;

public partial class joints : Node2D
{
	[Export] public float forceStrength = 2000f;
	[Export] public float stabilizationForce = 2000f;
	[Export] public float jointStabilizationForce = 200f;
	[Export] public float legSpeed = 50f;
	[Export] public float jumpHeight = 200000f;
	public RayCast2D groundRaycast;
	private RigidBody2D bodyReference;
	private RigidBody2D[] bodyParts = new RigidBody2D[3];
	private PinJoint2D[] pinJoints = new PinJoint2D[3];

	public override void _Ready()
	{
		groundRaycast = GetNode("../body/RayCast2D") as RayCast2D;
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
		float rotationForStabilization =  bodyReference.Rotation < 0 ? bodyReference.Rotation : -bodyReference.Rotation;
		bodyReference.ApplyTorque(rotationForStabilization * stabilizationForce);

		pinJoints[0].MotorTargetVelocity = (bodyReference.Rotation -bodyParts[0].Rotation) * jointStabilizationForce;

		if (Input.IsActionPressed("right")) {
			bodyReference.ApplyForce(new Vector2(forceStrength, 0));
			pinJoints[1].MotorTargetVelocity = legSpeed;
			pinJoints[2].MotorTargetVelocity = legSpeed;
		}
		else if (Input.IsActionPressed("left")) {
			bodyReference.ApplyForce(new Vector2(-forceStrength, 0));
			pinJoints[1].MotorTargetVelocity = -legSpeed;
			pinJoints[2].MotorTargetVelocity = -legSpeed;
		}
		else {
			pinJoints[1].MotorTargetVelocity = (bodyReference.Rotation -bodyParts[1].Rotation) * jointStabilizationForce;
			pinJoints[2].MotorTargetVelocity = (bodyReference.Rotation -bodyParts[2].Rotation) * jointStabilizationForce;
		}

		if(Input.IsActionJustPressed("jump") && groundRaycast.IsColliding()) {
			bodyReference.ApplyForce(new Vector2(0, -jumpHeight));
		}
	}
}
