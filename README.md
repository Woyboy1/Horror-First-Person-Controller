# Horror-First-Person-Controller
Quick implementation of a small Unity horror first-person controller package.

### Main Features:
- 3D player movement with a rigid-based movement
- Sprinting feature
- Camera headbob (Scales with the player speed)
- Interaction Controller used with Raycasts  

### Setup:
Because of the complex architecture of the controller, it is recommended to use the player prefab and modify it from there if you 
want any changes. But besides that, everything can be easily modified and integrated with other scripts.

### The Interactable Class:
The interactable.cs script can be easily modified to do other things. It is recommended to have interactable objects to inherit this
specific script due to the class being the only source that the PlayerInteractionController.cs script can access.

Have fun!
