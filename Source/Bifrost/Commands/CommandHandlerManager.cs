﻿#region License
//
// Copyright (c) 2008-2012, DoLittle Studios and Komplett ASA
//
// Licensed under the Microsoft Permissive License (Ms-PL), Version 1.1 (the "License")
// With one exception :
//   Commercial libraries that is based partly or fully on Bifrost and is sold commercially, 
//   must obtain a commercial license.
//
// You may not use this file except in compliance with the License.
// You may obtain a copy of the license at 
//
//   http://bifrost.codeplex.com/license
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
#endregion
using Bifrost.Execution;

namespace Bifrost.Commands
{
	/// <summary>
	/// Represents a <see cref="ICommandHandlerManager">ICommandHandlerManager</see>
	/// </summary>
	/// <remarks>
	/// The manager will automatically import any <see cref="ICommandHandlerInvoker">ICommandHandlerInvoker</see>
	/// and use them when handling
	/// </remarks>
	[Singleton]
	public class CommandHandlerManager : ICommandHandlerManager
	{
		readonly ITypeImporter _importer;
		ICommandHandlerInvoker[] _invokers;

		/// <summary>
		/// Initializes a new instance of a <see cref="CommandHandlerManager">CommandHandlerManager</see>
		/// </summary>
		/// <param name="importer">
		/// <see cref="ITypeImporter">TypeImporter</see> to use for discovering the 
		/// <see cref="ICommandHandlerInvoker">ICommandHandlerInvoker</see>'s to use
		/// </param>
		public CommandHandlerManager(ITypeImporter importer)
		{
			_importer = importer;
			Initialize();
		}

		private void Initialize()
		{
			_invokers = _importer.ImportMany<ICommandHandlerInvoker>();
		}

#pragma warning disable 1591 // Xml Comments
		public void Handle(ICommand command)
		{
		    var handled = false;

			foreach( var invoker in _invokers )
			{
				if( invoker.TryHandle(command) )
				{
				    handled = true;
				}
			}

            if(!handled)
            {
                throw new UnhandledCommandException(command);
            }
		}
#pragma warning restore 1591 // Xml Comments

	}
}