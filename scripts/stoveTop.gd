extends Area2D

@export var forceMag = 10000

func _on_body_entered(body):
	#SFX & Particles
	body.get_parent().health -= 1
	body.apply_central_impulse(Vector2(body.linear_velocity.x * -1 * forceMag, body.linear_velocity.y * -1 * forceMag))
	print(body.get_parent().health)
