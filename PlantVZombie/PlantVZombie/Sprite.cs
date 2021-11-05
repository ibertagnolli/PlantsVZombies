using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantVZombie
{
    class Sprite
    {

		private List<Image> images;
		private Point position; // Define the upper left corner of where the image is drawn.
		private Point hitboxSize;   // Define a width and height of the rectangle used for collision.

		/**
		 * A sprite is a sequence of images. A new Sprite always has at least one image
		 * (passed into the constructor).
		 * There is an assumption that these images are all the same size.
		 * 
		 * @param startingPosition the upper left corner of the image on the screen.
		 * @param initHitbox the width and height of the rectangle to be used for collision detection.
		 * @param img
		 */
		public Sprite(Point startingPosition, Point initHitbox, Image img)
		{
			position = startingPosition;
			hitboxSize = initHitbox;
			images = new List<Image>();
			images.Add(img);
		}

		/***
		 * Add img to the ArrayList of images
		 * 
		 * @param img
		 */
		public void add(Image img)
		{
			images.Add(img);
		}

		/**
		 * Get the image at frameNumber. If frameNumber would be out-of-bounds
		 * then mod it with the number of images.
		 * 
		 * The idea is that we can track the overall frame count of the game,
		 * pass it in, and this would cycle through the sprite images.
		 * 
		 * @param frameNumber
		 * @return the image at frameNumber mod the number of frames.
		 */
		public Image get(int frameNumber)
		{
			return images[frameNumber % images.Count()];
		}

		/**
		 * @return the upper left corner of the sprite's position.
		 */
		public Point getPosition()
		{
			return position;
		}

		/**
		 * Set the upper left corner of the sprite to newPosition.
		 * @param newPosition - a Point2D holds an x and y coordinate.
		 */
		public void moveTo(Point newPosition)
		{
			position = newPosition;
		}

		/**
		 * Change the current position by offset amount.
		 * @param offset - a Point2D holds an x and y coordinate.
		 */
		public void shiftPosition(Point offset)
		{
			position.X = position.X + offset.X; 
			position.Y = position.Y + offset.Y;
		}

		/**
		 * This returns the width and height of the collision rectangle, not a fully defined
		 * rectangle at some location.
		 * @return the Point2D holding the width and height.
		 */
		public Point getHitbox()
		{
			return hitboxSize;
		}

		/**
		 * Draw the image at its position.
		 * @param g - passed from the drawComponent override of the application
		 * @param frameNumber - defines which image to draw.
		 */
		public void draw(Graphics g, int frameNumber)
		{
			//might need frame? 
			g.DrawIcon( null, (int)position.X, (int)position.Y);
		}

		/**
		 * See if point is within the rectangle from position to position + hitbox
		 * @param point
		 * @return true if the point is in the rectangle and false otherwise.
		 */
		public bool isCollidingPoint(Point point)
		{
			return point.X >= position.X && point.X <= position.X + hitboxSize.X && // within x range
				   point.Y >= position.Y && point.Y <= position.Y + hitboxSize.Y;   // within y range				
		}


		/**
		 * Check if the hitbox of this sprite overlaps the hitbox of an other sprite.
		 * The basic approach is to see if one is totally to the left, right, above, or 
		 * below the other sprite. If it is, it is not overlapping.
		 * @param other - the other sprite
		 * @return the collision status.
		 */
		public bool isCollidingOther(Sprite other)
		{
			// See if this rectangle is above the other
			if (position.Y + hitboxSize.Y < other.position.Y)
				return false;
			// See if this rectangle is below the other
			if (position.Y > other.position.Y + other.hitboxSize.Y)
				return false;

			// See if this rectangle is left of the other
			if (position.Y + hitboxSize.Y < other.position.Y)
				return false;
			// See if this rectangle is right of the other
			if (position.Y > other.position.Y + other.hitboxSize.Y)
				return false;

			// If it is not above or below or left or right of the other, it is colliding.
			return true;
		}
	}
}
