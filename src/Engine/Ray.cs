// Copyright (c) W2.Wizard 2021. All Rights Reserved.

using System.Numerics;

namespace FlaxCLI.Engine
{
	public struct Ray
	{
		public Vector3 Position;

		public Vector3 Direction;

		public Ray(Vector3 position, Vector3 direction)
		{
			this.Position = position;
			this.Direction = direction;
		}
	}
}