extends Area2D
#@export var hp = 5
func _on_body_entered(body):
	#
	body.get_parent().health -= 1
	print(body.get_parent().health)
	#hp -= 1
	#wait(5)
	#print(hp)
	
#func _process(delta):
	
	#if(hp <= 0):
		#hp = 5
		#get_tree().reload_current_scene()
#func wait(seconds: float) -> void:
  #await get_tree().create_timer(seconds).timeout		
