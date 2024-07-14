using Godot;
using System;
using System.Linq;

public partial class fracture : Node2D
{
    [Export] public float rigidBody2DMass = 0.01f;

    public void BreakObject()
    {
		GD.Print("meow");
        foreach (var child in GetChildren().OfType<StaticBody2D>().ToList())
        {
            RigidBody2D rigidBody = new RigidBody2D();
            rigidBody.Mass = rigidBody2DMass;

            AddChild(rigidBody);

            foreach (var grandchild in child.GetChildren()) {
                child.RemoveChild(grandchild);
                rigidBody.AddChild(grandchild);
            }

            RemoveChild(child);
            child.QueueFree();
        }
    }
}