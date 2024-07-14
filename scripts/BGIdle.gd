extends AnimatedSprite2D

@onready var anim = $AnimatedSprite2D

func _ready():
	play("BGIdle")
