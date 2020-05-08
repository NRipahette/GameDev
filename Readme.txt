Character movement --> Paladin/PlayerMovement.cs
Camera control --> Camera folder Mainly inspired from sources on the net with a few tweaks to make it work in my project.

State Pattern and Observer pattern --> GameManager.cs
Interface --> Paladin/IHealth.cs implemented in Paladin/Playerstats.cs and Enemy/EnemyController.cs

For the spells, It is a bundle from the assets store I got from an "HumbleBunlde" bundle
My work on thoses is in the "Spells" folder and when the spell is instanciated with his effect, 
the script for the collisions of the effect was done. I went in and looked for ways to make the spells interact with the my world, 
essentially deal damage when it hits an enemy, in "Assets/KriptoFX/Realistic Effects Pack v4/Effects/Scripts/RFX4_PhysicsMotion.cs"

Everything else I didn't mentionned is my code.