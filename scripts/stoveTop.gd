extends Area2D

func _on_body_entered(body):
	#Subtract health
	#Temporary Immunity
	#Give Opposite Force
	print(body.super().health)
