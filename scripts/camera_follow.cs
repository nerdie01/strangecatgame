using Godot;

public partial class camera_follow : Camera2D
{
	[Export] public double lerpSpeed = 3.0;
	private RigidBody2D cat;
	private Vector2 offset = new Vector2(1000, 0);
	
	public override void _Ready()
	{
		cat = GetNode("../cat/body") as RigidBody2D;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		GlobalTransform = GlobalTransform.InterpolateWith(cat.GlobalTransform.Translated(offset), (float)(lerpSpeed * delta));
	}
}
