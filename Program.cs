using System;
using Silk.NET.Input;
using Silk.NET.Maths;
using Silk.NET.Windowing;

namespace Tutorial {
	class Program {
		private static IWindow window;
		private static System.Timers.Timer timer;

		private static void Main(string[] args) {
			Console.WriteLine("Program started");

			//Create a window.
			WindowOptions options = WindowOptions.Default;
			options.Size = new Vector2D<int>(800, 600);
			options.Title = "LearnOpenGL with Silk.NET";
			options.API = new GraphicsAPI(ContextAPI.OpenGL, ContextProfile.Compatability, ContextFlags.Default, new APIVersion(2, 1));

			window = Window.Create(options);
			Console.WriteLine($"{nameof(window)} created");

			//Assign events.
			window.Load += OnLoad;
			window.Update += OnUpdate;
			window.Render += OnRender;

			timer = new System.Timers.Timer(10.0d * 1000.0d) {
				AutoReset = false,
				Enabled = true
			};
			timer.Elapsed += (object sender, System.Timers.ElapsedEventArgs e) => {
				window.Close();
			};

			Console.WriteLine($"Running {nameof(window)}...");
			//Run the window.
			window.Run();
		}


		private static void OnLoad() {
			//Set-up input context.
			IInputContext input = window.CreateInput();
			for (int i = 0; i < input.Keyboards.Count; i++) {
				input.Keyboards[i].KeyDown += KeyDown;
			}
			Console.WriteLine("OnLoad() called");
		}

		private static void OnRender(double obj) {
			//Here all rendering should be done.
		}

		private static void OnUpdate(double obj) {
			//Here all updates to the program should be done.
		}

		private static void KeyDown(IKeyboard arg1, Key arg2, int arg3) {
			//Check to close the window on escape.
			if (arg2 == Key.Escape) {
				window.Close();
			}
		}
	}
}
