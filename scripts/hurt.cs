using Godot;
using System;

public partial class hurt : Area2D
{
	[Export] public string groupToHit;

    public override void _Ready()
    {
        GetNode<Area2D>("StoveTop").Connect("body_entered",new Callable(this, "ReactionToBody"));
    }

    public void ReactionToBody(RigidBody2D rb)
	{
		GD.Print("TestTest");
		if(rb.GetParent().IsInGroup(groupToHit))
		{
			
		}
	}
}
