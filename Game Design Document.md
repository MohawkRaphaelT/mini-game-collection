**Introduction**

Our prototype is a two player 2D top down co-op space defense game, where you and one other player do your best to defend Earth against asteroids that are flying towards it. The players have to shoot the asteroids before they get too close and destroy the Earth.

**Objective Statement**

“Can we make a short, two player objective defense game that's fast paced and intense. Testing at this level could allow us to add more elements and mechanics to the game, allowing it to scale into a larger project.”

**Mechanics**

**Movement**  
The player has eightway directional omni movement, allowing them to move anywhere around the screen. Players can press B to dash in the direction they’re facing, on a cooldown of 3 seconds. If the player flies into an asteroid, their ship slows down by 50% for 10 seconds and they can only fire at 50% speed before being repaired and going back to 100%.

**Astroids**  
Waves of asteroids appear from all sides of the screen, all aimed towards the middle of the screen, where Earth is. If the asteroids collide with the Earth, the Earth gets destroyed, and the players lose. The asteroids spawn in two sizes, large asteroids and small asteroids.

**Shooting**  
Players use the A button to shoot a laser that fires in the direction your ship is facing. Players shoot 2 lasers per second. Shooting small asteroids destroys them in one shot, destroying large asteroids splits them into 2 small asteroids.

**Timer**  
Players are on a 60 second timer that counts down to 0, if any asteroids hit the Earth in that time, the players lose. After 60 seconds, the wave of asteroids stops and the players win

**Design rationale**

We decided to go with a space themed defense game, as inspiration from space invaders, which is a very iconic arcade machine. While space invaders is locked to left and right movement, we decided to go with an omni directional movement, to have a bit more leeway with what we design. As players have begun enjoying face-paced gameplay more and more, we decided we should add a twist that makes the game quick and intense, which is why we added the dash mechanic. The dash mechanics purpose is to add another variable of thinking, as if you are too hyper with how you dash, you may send yourself into an asteroid and be punished for it. We also decided to make the game two player, as this adds more strategy into the game, as you can plan with your team mate who will defend where, and communicate with them on where they need to be and what they need to do. We were close to adding a shield mechanic rather then the dash, but decided against it, as it doesn't add the same fast paced feel that we are looking for.

**Asset Sources**

All assets are from the repository, and no AI was used in the making of this game.  
