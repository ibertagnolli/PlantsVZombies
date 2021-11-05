using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantVZombie
{
    class Actor : Sprite
    {
		//public class Actor extends Sprite implements Attack
		//{

	    private int health;         // Current health of an Actor object
		private int fullHealth;     // The max health if healed. Used in the drawn health bar.
		protected int attackDamage;     // Damage this Actor does to another Actor.
		private int coolDownCounter;// Current count of the cooldown.
		private int coolDown;       // Starting cool down value 
		private int speed;       // The speed at which it moves

		/**
		 * Construct a new Actor. It needs the info to make the Sprite part of itself.
		 * @param startingPosition
		 * @param initHitbox
		 * @param img
		 * @param health
		 * @param coolDown
		 * @param speed
		 * @param attackDamage
		 */
		public Actor(Point startingPosition, Point initHitbox, Image img, int health, int coolDown, int speed, int attackDamage):base(startingPosition, initHitbox, img)
		{
			
			this.health = health;
			this.fullHealth = health;
			this.coolDownCounter = coolDown;
			this.coolDown = coolDown;
			this.speed = speed;
			this.attackDamage = attackDamage;
		}

		/**
		 * Only moves in x.
		 */
		public void move()
		{
			shiftPosition(new Point(speed, 0));
		}

		/**
		 * Getter for speed
		 * @return the speed
		 */
		public double getSpeed()
		{
			return speed;
		}

		/**
		 * Count down the cool down.
		 */
		public void decrementCooldown()
		{
			coolDownCounter--;
		}

		/**
		 * Update the internal state of the Actor. This means decrement the cool down counter.
		 */
		public void update()
		{
			decrementCooldown();
		}

		/**
		 * If the cooldown counter hits 0, the Actor is ready to do something.
		 * @return
		 */
		public bool isReadyForAction()
		{
			if (coolDownCounter <= 0)
				return true;
			return false;
		}

		/**
		 * Reset the cool down counter to its starting value.
		 */
		public void resetCoolDown()
		{
			coolDownCounter = coolDown;
		}

		/**
		 * Modify the health by change value.
		 * @param change
		 */
		public void changeHealth(int change)
		{
			health += change;
		}

		/**
		 * Check whether the Actor still has some health.
		 * @return
		 */
		public bool isAlive()
		{
			return health > 0;
		}

		/**
		 * Since we don't have an easy way of showing health using a nice series of images,
		 * provide health feedback with a health status bar.
		 * @param g
		 */
		//public void drawHealthBar(Graphics g)
		//{
		//	Point pos = this.getPosition();
		//	Point box = this.getHitbox();
		//	g.setColor(Color.BLACK);
		//	g.drawRect((int)pos.getX(), (int)pos.getY() - 10, (int)box.getX(), 5);
		//	g.setColor(Color.RED);
		//	g.fillRect((int)pos.getX(), (int)pos.getY() - 10, (int)(box.getX() * this.health / (double)this.fullHealth), 5);
		//}


		/**
		 * If something should happen when the Actor is dead, do it here (or override it).
		 * @param others
		 */
		public void removeAction(List<Actor> others)
		{

		}

		//	/**
		//	 * An Actor doesn't need to set collision status, but a Zombie can override this.
		//	 * @param other
		//	 */
		public void setCollisionStatus(Actor other)
		{
		}

		/**
		 * An attack means the two hotboxes are overlapping and the
		 * Actor is ready to attack again (based on its cooldown).
		 * 
		 * @param other
		 */

	public void attack(Actor other)
		{
			if (this != other && this.isCollidingOther(other))
			{
				if (this.isReadyForAction())
				{
					other.changeHealth(-attackDamage);
					this.resetCoolDown();
				}
			}
		}

		public void endGame()
		{
			if (this.getPosition().X == 0)
			{
				speed = 0;
				//figure this out 
			   // Form1.Close();
			}

		}


	}
}

