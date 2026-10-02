# Unity Textbook Walkthrough

This repo contains the Unity project that I've been working on following the Unity textbook chapters. 

## How to Test

To test, import this Unity project and press play. The project currently contains the behaviors described in chapters 1, 2, 5, 6, 7, 8, 9. So you can use WASD to move the player around, use the mouse to look around, and left click to shoot bullets.

There is an enemy spawner which spawns enemies every 5 seconds for the first 25 seconds. The enemies have AI which will track the player down and shoot the player. If the enemies are too far from the player, they will instead go for the player's base, which is a cyan cube near the back of the map.

If either the player or the base gets shot too many times, you will be taken to a lose screen. If you kill all of the enemies and the spawners are finished, then you will be taken to a win screen.
