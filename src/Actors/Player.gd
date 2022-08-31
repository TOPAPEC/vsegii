extends "res://src/Actors/ActorBase.gd"

export var movement_speed: = 1000
var velocity: = Vector2.ZERO
var up_direction = Vector2.UP

func _physics_process(delta: float) -> void:
	var is_jump_interrupted: = Input.is_action_just_released("jump") and velocity.y < 0.0
	var direction: = get_movement_direction()
	velocity = calculate_movement_velocity(velocity, direction, speed, is_jump_interrupted)
	
	
	velocity = move_and_slide(velocity, up_direction)


func get_movement_direction() -> Vector2:
	return Vector2(
		Input.get_action_strength("move_right") - Input.get_action_strength("move_left"),
		-1.0 if Input.is_action_just_pressed("jump") and is_on_floor() else 1.0
	)

func calculate_movement_velocity(velocity, direction, speed, is_jump_interrupted) -> Vector2:
	