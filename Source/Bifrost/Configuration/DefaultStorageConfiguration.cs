﻿#region License
//
// Copyright (c) 2008-2015, Dolittle (http://www.dolittle.com)
//
// Licensed under the MIT License (http://opensource.org/licenses/MIT)
//
// You may not use this file except in compliance with the License.
// You may obtain a copy of the license at 
//
//   http://github.com/dolittle/Bifrost/blob/master/MIT-LICENSE.txt
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
#endregion
using Bifrost.Entities;
using Bifrost.Execution;

namespace Bifrost.Configuration
{
    /// <summary>
    /// Represents an implementation of <see cref="IDefaultStorageConfiguration"/>
    /// </summary>
    public class DefaultStorageConfiguration : ConfigurationStorageElement, IDefaultStorageConfiguration
    {
#pragma warning disable 1591 // Xml Comments

        public override void Initialize(IContainer container)
        {
            if (EntityContextConfiguration == null)
                EntityContextConfiguration = new NullEntityContextConfiguration();

            EntityContextConfiguration.BindDefaultEntityContext(container);
            base.Initialize(container);
        }
#pragma warning restore 1591  //Xml Comments
    }
}
