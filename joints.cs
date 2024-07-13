using Godot;
using System;
using System.Security.AccessControl;

public partial class joints : Node2D
{
	[Export] public float forceStrength = 2f;
	[Export] public float stabilizationForce = 200f;
	[Export] public float jointStabilizationForce = 100f;
	[Export] public float legSpeed = 100f;
	[Export] public float jumpHeight = 1000f;
	private RigidBody2D bodyReference;
	private RigidBody2D[] bodyParts = new RigidBody2D[3];
	private PinJoint2D[] pinJoints = new PinJoint2D[3];
	private CollisionShape2D[] legCollider = new CollisionShape2D[2];

	public override void _Ready()
	{
		bodyReference = GetNode("../body") as RigidBody2D;
		bodyParts[0] = GetNode("../head") as RigidBody2D;
		bodyParts[1] = GetNode("../leg_1") as RigidBody2D;
		bodyParts[2] = GetNode("../leg_2") as RigidBody2D;
		pinJoints[0] = GetNode("joint_head") as PinJoint2D;
		pinJoints[1] = GetNode("joint_leg_1") as PinJoint2D;
		pinJoints[2] = GetNode("joint_leg_2") as PinJoint2D;
		legCollider[0] = GetNode("../leg_1/Leg1Collider") as CollisionShape2D;
		legCollider[1] = GetNode("../leg_2/Leg2Collider") as CollisionShape2D;
	}

    public override void _PhysicsProcess(double delta)
    {
		float rotationForStabilization =  bodyReference.Rotation < 0 ? bodyReference.Rotation + 2*MathF.PI : bodyReference.Rotation;
		GD.Print(rotationForStabilization * stabilizationForce);
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

		if(Input.IsActionJustPressed("jump")) {
			GD.Print("meow");
			bodyReference.ApplyForce(new Vector2(0, -jumpHeight));
		}
    }
}
