extends Node2D

const max_hp = 5
var hp = max_hp

# Called when the node enters the scene tree for the first time.
func _ready():
	set_hp_label()

func set_hp_label() -> void:
	$HealthLable.text ="HP: %s" % hp
# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	pass
func damage() -> void:
	hp -= 1
	if hp <= 0:
		get_tree().reload_current_scene()
