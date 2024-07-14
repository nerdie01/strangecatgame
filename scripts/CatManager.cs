using Godot;
using System;

public partial class CatManager : Node
{
	[Export] public int health = 3;

	public override void _Process(double delta)
	{
		if(health <= 0)
		{
			GetTree().ReloadCurrentScene();
		}
	}

	public override void _UnhandledInput(InputEvent @event)
{
    if (@event is InputEventKey eventKey)
        if (eventKey.Pressed && eventKey.Keycode == Key.E)
            health--;
}
}
