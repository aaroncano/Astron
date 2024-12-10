# Astron
Astron is a 2D video game inspired by Asteroids and Geometry Wars. Created in 2020 with Unity 2020.3.7f1 and C#.

[Download Astron on Itch.io](https://aaroncanoc.itch.io/astron)

[Youtube video | Example](https://www.youtube.com/watch?v=Z-d9j_P8Eg4)

## Project Structure
The project follows a common structure for Unity video games, with folders organized by assets and their categories. It includes folders for sprites, prefabs, behavior scripts, UI, sound, and other elements like audio mixers or particle effects. The game's logic and functionality are divided across various specialized scripts, with file names indicating their purpose. The scripts commonly utilize design patterns such as Singleton and inheritance. Additionally, attribute variations are handled through ranges to dynamically adjust properties within the game.

## Gameplay
The goal of the game is to eliminate approaching enemies by moving around the map, aiming, and shooting, while striving to achieve the highest possible score through enemy eliminations and collecting items. There are 8 types of enemies, with 2 subclasses for most of them, varying in toughness and aggression. Enemies are distinguished by their geometric shapes and colors.

![eha15X](https://github.com/user-attachments/assets/77851afd-ddf8-4956-a104-aea4d329dc37)

## Waves
The game operates in waves that start off shorter and with fewer enemies, but increase in difficulty and enemy count as the player progresses. As the waves advance, the likelihood of encountering more powerful enemies also increases. 

![SHVJr+](https://github.com/user-attachments/assets/b7f0c6a9-68e7-4049-9a73-52917d2c8af1)

## Rewards / Upgrades
At the end of each wave, the player is rewarded with items that can be collected by approaching them. Rewards include weapon upgrades, bullets, shooting speed enhancements, extra lives, bombs, and special powers such as bullets that freeze or push enemies.

![imagen](https://github.com/user-attachments/assets/69579bcd-2fde-452b-b208-93ea6b42022c)

## How to play
The player is controlled using the WASD keys, while the mouse is used for aiming and shooting. The ship has an inertia effect, meaning releasing the control after moving will keep it drifting in that direction until it completely loses momentum. The player also has a limited-use bomb, activated by the space bar, which destroys all enemies on screen when used.

![lCcUSM](https://github.com/user-attachments/assets/c568a104-da29-4cbf-b683-c409b91d604d)

## Score System
The game ends when the player loses all lives. If the player's score qualifies for the local top scores, they will be prompted to enter their name to record their score, after which they can start a new game.

![imagen](https://github.com/user-attachments/assets/6773e742-e18f-41b0-845c-83725f1c47eb)

## Menu

![imagen](https://github.com/user-attachments/assets/37742c9c-22cd-43f1-9691-0178f269f9e6)

## Credits
- Aarón Cano: Code, UI, Sprites, Sounds, and Animations
