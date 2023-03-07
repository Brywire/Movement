using System.Numerics; // Vector2
using Raylib_cs; // Color
using System.Collections.Generic; // For lists

/*
In this class, we have the properties:

- Vector2  Position
- float    Rotation
- Vector2  Scale

- Vector2 TextureSize
- Vector2 Pivot
- Color Color

Methods:

- AddChild(Node child)
- RemoveChild(Node child, bool keepAlive = false)
*/

namespace Movement
{
	class MovingBall : SpriteNode
	{
		Vector2 Velocity = new Vector2(300, 300);

		// constructor + call base constructor
		public MovingBall() : base("resources/dvdlogo.png")
		{
			Position = new Vector2(Settings.ScreenSize.X / 2, Settings.ScreenSize.Y / 4);
			Color = Color.ORANGE;
		}

		// Update is called every frame
		public override void Update(float deltaTime)
		{
			Move(deltaTime);
			BounceEdges();
		}

		// your own private methods
		private void Move(float deltaTime)
		{
			// TODO implement
			// Position.X += xspeed * deltaTime;
			// Position.Y += yspeed * deltaTime;

			Position += Velocity * deltaTime;
		}

		private void BounceEdges()
		{
			float scr_width = Settings.ScreenSize.X;
			float scr_height = Settings.ScreenSize.Y;
			float spr_width = TextureSize.X;
			float spr_heigth = TextureSize.Y;

			// TODO implement...
			if (Position.X > scr_width - TextureSize.X / 2)
			{
				Position.X = scr_width - TextureSize.X / 2;
				// xspeed *= -1;
				Velocity.X *= -1;
			}
			if (Position.X < 0 + TextureSize.X / 2)
			{
				Position.X = 0 + TextureSize.X / 2;
				Velocity.X *= -1;
			}

			if (Position.Y > scr_height - TextureSize.Y / 2)
			{
				Position.Y = scr_height - TextureSize.Y / 2;
				Velocity.Y *= -1;
			}
			if (Position.Y < 0 + TextureSize.Y / 2)
			{
				Position.Y = 0 + TextureSize.Y / 2;
				Velocity.Y *= -1;
			}
		}

	}
}
