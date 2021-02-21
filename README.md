# Asteroid Shooter (Unity 3D 2019.4.8f1)
Prototype based on a recruitment task for Fuero Games

</br>

<details>
  <summary>Recruitment task description:</summary>

  ```
1. The map is endless.

2. The camera follows you around.

3. Your ship on collision with an asteroid should be destroyed.
a. UI text appear “You lose”
b. Button “Restart” appear that restarts the game.
c. All simulation is held while the game is lost.

4. You steer your ship with W or Arrow up - Forward; A, D or Arrow left, right - Rotation.
Your ship shoots automatically every 0.5 seconds.

5. Your bullets are destroyed after they existed for 3 seconds or after a collision with the asteroid.

6. After the bullet destroys the asteroid, a score is increased and Text on UI with score changes.

7. Asteroids are destroyed after a collision with other asteroids or with the bullet.

7.1. Destroyed asteroids are re-spawned after 1 second at random position that is outside of the player view frustum
(asteroid can spawn on another asteroid causing immediate collision)

8. Asteroids should spawn on the grid 160 x 160 units, one asteroid in the center of one grid tile.

9. On the map, you should generate 25 600 asteroids.

10. Ship spawns at the center of the map.

11. All asteroids must have random speed larger than 0 and random direction.

12. Make sure every asteroid speed and direction is persistent every game.

13. All Asteroids should be always simulated (flying and colliding) even if they are not visible.
  ```
</details>

<details>
  <summary>Own functionalities added to project:</summary>

  ```
1. Movable background with depth effect.

2. More realistic spaceship movement.

3. Implement Lightweight RP.

4. Add random asteroids torque.

5. Application pause and resume system (when window is active/inactive).

6. A move sensor to detecting asteroids in player range.

7. Possibility to change distance between grid cells.
  ```
</details>
