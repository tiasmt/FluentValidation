#region License
// Copyright (c) .NET Foundation and contributors.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// The latest version of this file can be found at https://github.com/FluentValidation/FluentValidation
#endregion

namespace FluentValidation.Internal {
		using System.Collections.Generic;
		using System.Linq;

		internal class CompositeValidatorSelector : IValidatorSelector {
				private readonly IEnumerable<IValidatorSelector> _selectors;
				private readonly bool _isFilter;

				public CompositeValidatorSelector(IEnumerable<IValidatorSelector> selectors, bool isFilter) {
						_selectors = selectors;
						_isFilter = isFilter;
				}

				public bool CanExecute(IValidationRule rule, string propertyPath, IValidationContext context) {
						return _isFilter ? _selectors.All(s => s.CanExecute(rule, propertyPath, context))
							: _selectors.Any(s => s.CanExecute(rule, propertyPath, context));
				}
		}
}
