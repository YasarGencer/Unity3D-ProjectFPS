# Unity3D-ProjectTPS

## Player
- InputManager : Controls movement
- Movement:
  - Motor: Includes the main movement functions
  - Look: Controls player look
- Health
- Interact: Looks for interactable objects
- UI
- Weapons:
  - PlayerWeapon: Abstract Class
  - PlayerWeaponManager: Inherits PlayerWeapon
  - StructWeapon: Scriptable struct object for weapon
  - Weapons:
    - Pistol
    - Rifle

## Enemy
- EnemyMain
- EnemyBaseState: Abstarct Class
- EnemyStateManager: Inherits EnemyBaseState
- States:
  - Patrol State

## Interactables
- Interactables
- InteractionEvent
- Interactions:
  - Event Only: Creates interactables uses only events
  - Keypad: Opens and closes a choosen door
  - WeaponInteractable: Picks up a choosen weapon
