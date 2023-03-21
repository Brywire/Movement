using System.Numerics; // Vector2
using System;
using Raylib_cs; // Color

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
	class AcceleratingBall : SpriteNode
	{
		// your private fields here (MaxSpeed)
		Vector2 Velocity = new Vector2();
		Vector2 Acceleration = new Vector2();
		float maxspeed = 1000;

		// constructor + call base constructor
		public AcceleratingBall() : base("resources/ball.png")
		{
			Position = new Vector2(Settings.ScreenSize.X / 2, Settings.ScreenSize.Y / 4);
			Color = Color.RED;
		}
			private Vector2 Limit(Vector2 vec2, float max)
			{
				Vector2 limited = vec2;
				if (limited.Length() > max)
				{
					limited = Vector2.Normalize(limited);
					limited *= max;
				}
				return limited;
			}
		// Update is called every frame
		public override void Update(float deltaTime)
		{
			Acceleration = new Vector2(40, 30);
			Velocity = Limit(Velocity, maxspeed);
			Move(deltaTime);
			WrapEdges();
			// Check to see what the max speed is
			//Console.WriteLine(Velocity.Length());
		}

		// your own private methods
		private void Move(float deltaTime)
		{
			// TODO implement
			Velocity += Acceleration * deltaTime;
			Position += Velocity * deltaTime;

			// limit to a maximum speed of 1000 pixels/second
			Acceleration *= 0;
		}

		private void WrapEdges()
		{
			float scr_width = Settings.ScreenSize.X;
			float scr_height = Settings.ScreenSize.Y;
			float spr_width = TextureSize.X;
			float spr_heigth = TextureSize.Y;

			// TODO implement...
			if (Position.X > scr_width)
			{
				Position.X = 0;
			}

			if (Position.X < 0)
			{
				Position.X = scr_width;
			}

			if (Position.Y > scr_height)
			{
				Position.Y = 0;
			}

			if (Position.Y < 0)
			{
				Position.Y = scr_height;
			}


		}

	}
}
