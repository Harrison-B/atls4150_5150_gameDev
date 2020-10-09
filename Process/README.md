# Process Documentation
---
## 9/23/2020
Started off with the branch of Professor Bethancourt's breakout clone, adding everything we did in class. This included:
- Ability for the player to shoot projectiles
- A new projectile type for enemies that uses the same projectile script but with an added variable to control direction, and uses tags and triggers for collision detection. This also helps make sure the projectiles do not collide with each other.
- Use a Sin wave to move the enemies gradually from side to side. 
- A health bar using UI elements

## 9/28/2020
### Concept Development
- **Chosen Idea:** Food themed snake shmup
- Formal Elements:
    - Objectives: Player has normal shmup objectives like shooting enemies and getting to the end of levels, in addition, they have the objective to match up powerups and grow their character
    - Resources: Powerups alter the player's abilities but also increase the player's size. Powerups can be combined.
    - Conflict: Player must balance powerups with their size and the risk of recieving damage
- Puzzles/Challenges:
    - Combining powerups to create new ones, some combinations might be bad or damage the player?
    - More powerups = bigger size = more risk
- Basic Rules
    1. Player can move anywhere on screen and shoot from anywhere on screen
    2. Enemies can shoot, player should avoid getting hit by enemy or enemy projectile
    3. Powerups are added to players size and change player abilities

### Game Development
- Added capability for player to move anywhere on screen
- Added vertical movement of enemies
- Added indidivual enemy spawn and movement
- Added side bounds for enemies

## 9/30/2020
- Added powerups that follow the player when collected
- Changed how collisions with the player work to better support the snake mechanic

## 10/5/2020
- Added ability for the apples to get hit and break off the chain after where they got hit
- Put enemies on their own layer with player projectiles so that the powerups wouldn't hit the enemies
- Changed player sprite to something that is not a block
- Changed follow distance from player to be distance from the distance between powerups
- Fixed bug where if only the last powerup was hit it didn't remove itself
- If the last powerup is deleted, it tries to delete the player and throws an error (fixed)

Power up Brainstorming:
- Powerup that shoots its own projectiles randomly
- Powerup that gives burst / spread shot but slows the player down
- Powerup that adds regenerating sheild in front of the player

## 10/7/2020
- Added explision to powerups when they get hit
- Got player feedback from Alexandria:
    - When player and enemy collide something should happen
- Added pineapple

## 10/8/2020
- Found cause of bug that would cause the powerups to start floating by themselves in the void while picked up. It looks like it was an issue with them being deleted when touching a wall when following the player. Disabled them deleting themselves when they touch a wall and are following the player.
- Added apple's ability to shoot and pineapples ability to add burst shoot