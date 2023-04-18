using System.Numerics;

namespace Movement
{
	abstract class MoverNode : SpriteNode
	{
		// public fields (!!!)
		public Vector2 Velocity;
		public Vector2 Acceleration;
		private float mass; // OK, let's keep this one private

		// public Vector2 Velocity { 
		// 	get { return velocity; }
		// 	set { velocity = value; }
		// }
		// public Vector2 Acceleration { 
		// 	get { return acceleration; }
		// 	set { acceleration = value; }
		// }
		public float Mass { 
			get { return mass; }
			private set { mass = value; }
		}

		// constructor
		protected MoverNode(string title) : base(title)
		{
			Velocity = new Vector2(0, 0);
			Acceleration = new Vector2(0, 0);
			Mass = 1.0f;
		}

		public override void Update(float deltaTime)
		{
			// override in your subclass
		}

		// Protected methods to be called from subclass
		protected void Move(float deltaTime)
		{
			// Motion 101. Apply the rules.
			Velocity += Acceleration * deltaTime;
			Position += Velocity * deltaTime;
			// Reset acceleration
			Acceleration *= 0.0f;
		}

		protected void AddForce(Vector2 force)
		{
			Acceleration += force / Mass;
		}

		protected void BounceEdges()
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

		protected void WrapEdges()
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
