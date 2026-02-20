Unity Gameplay Systems Demo
🎮 Overview
This repository contains a Unity game prototype developed to demonstrate structured gameplay system architecture, UI integration, and event-driven interactions using C#.
The project focuses on clean scene separation, modular scripting practices, and controlled UI state management within a multi-scene Unity setup.

🧩 Implemented Systems
🔹 Main Menu System
Scene-based navigation
Start button functionality
Clean separation between menu and gameplay scenes
Controlled scene loading using SceneManager

🔹 Game Timer System
Countdown timer with delayed activation
Timer only starts after game initialization
Automatic Game Over state when time reaches zero
Coroutine-based delay before returning to Main Menu
UI visibility state control (enable/disable management)

🔹 Game Over System
Dynamic UI activation
Timed transition back to Main Menu
Clean reset of UI state between scene loads

🔹 NPC Interaction System
Context-based NPC responses
Event-triggered dialogue display
Conditional reaction system (e.g., fire button interaction)
UI message display control

🔹 Inventory System
ScriptableObject-based item design
Item pickup system using triggers
Dynamic UI slot updating
Item usage behavior
Button-driven event integration

🔹 Button-Driven Event System
Sound-triggered commands
Conditional event recognition
NPC response to specific item usage (e.g., fire exit logic)

🛠 Technologies Used
Unity Engine (6.x LTS)
C#
TextMeshPro
Unity SceneManager API
Coroutines
ScriptableObjects
CharacterController
Modular MonoBehaviour architecture

🧠 Concepts Demonstrated
Scene lifecycle control
UI state synchronization
Script communication between objects
Event-driven system design
Conditional logic handling
Coroutine timing management
Separation of concerns in gameplay systems
