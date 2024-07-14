extends Node

@export var health: int = 3

func _process(delta):
	
	if(health <= 0):
		get_tree().reload_current_scene()
