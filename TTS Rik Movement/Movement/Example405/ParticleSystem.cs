using System; // Console
using System.Numerics; // Vector2
using System.Collections.Generic; // List
using Raylib_cs; // Color

namespace Movement
{
	class ParticleSystem : Node
	{
		// your private fields here (add Velocity, Acceleration, and MaxSpeed)
		public List<Particle> particles;
		private List<Color> colors;
		private Random rand;
		public float timer;
		

		// constructor + call base constructor
		public ParticleSystem(float x, float y) : base()
		{
			Position = new Vector2(x, y);
			timer = 0.0f;
			rand = new Random();



			colors = new List<Color>();
			colors.Add(Color.WHITE);
			colors.Add(Color.ORANGE);
			colors.Add(Color.RED);
			colors.Add(Color.BLUE);
			colors.Add(Color.GREEN);
			colors.Add(Color.BEIGE);
			colors.Add(Color.SKYBLUE);
			colors.Add(Color.YELLOW);

			particles = new List<Particle>();

		}

		// Update is called every frame
		public override void Update(float deltaTime)
		{
			
			timer += deltaTime;
		
			if (timer > 0.2f)
			{
				float randX = (float)rand.NextDouble();
				float randY = (float)rand.NextDouble();
				Vector2 vel = new Vector2(randX, randY) * 200;
				vel -= new Vector2(100, 100);
				Particle p = new Particle(0,0 , colors[rand.Next()%colors.Count]);
				particles.Add(p);
				p.Velocity = vel;
				
				AddChild(p);
				timer = 0.0f;
			}
			
			if (particles.Count > 25)
			{
				RemoveChild(particles[0]);
				particles.RemoveAt(0);
			}
			
		}


	}
}
