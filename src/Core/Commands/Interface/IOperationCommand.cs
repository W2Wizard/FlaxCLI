// Copyright (c) W2.Wizard 2021. All Rights Reserved.

namespace FlaxCLI.Commands
{
	/// <summary>
	///	Defines a CLI operation with code execution.
	/// </summary>
	public interface IOperationCommand
	{
		/// <summary>
		/// Additional parameter descriptions which inform what kind of arguments can be passed to
		/// <see cref="Execute(string[])" />.
		/// </summary>
		string ParamDescription { get; }

		/// <summary>
		/// The active execution of the command.
		/// </summary>
		/// <param name="args">Additional optional parameters passed to the command.</param>
		void Execute(string[] args);
	}
}