using Godot;
using System;

public partial class CatManager : Node
{
	public int health = 3;

	public override void _Process(double delta)
	{
		if(health <= 0)
		{
			GetTree().ReloadCurrentScene();
		}
	}
}
