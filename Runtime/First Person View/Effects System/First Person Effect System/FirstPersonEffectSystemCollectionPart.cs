/*
 *	Copyright (c) 2020, <AUTHOR>
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace Andtech.Ego {

	public partial class FirstPersonEffectSystem {
		struct EffectModuleManifest {
			public EffectModule Module { get; set; }
			public FirstPersonViewAnchor Anchor { get; set; }
			public TransformComponent Component { get; set; }
			public bool WorldSpace { get; set; }
			public Func<Vector3> Function { get; set; }
		}

		private List<EffectModule> modules = new List<EffectModule>();
		private List<EffectModuleManifest> manifests = new List<EffectModuleManifest>();

		public void Add(EffectModule module) {
			modules.Add(module);
			module.StartCoroutine = StartCoroutine;
			module.StopCoroutine = StopCoroutine;

			if (module is IPositionEffect positionEffect) {
				foreach (var methodInfo in module.GetType().GetInterfaceMap(typeof(IPositionEffect)).TargetMethods) {
					var attribute = Attribute.GetCustomAttribute(methodInfo, typeof(TransformEffectAttribute)) as TransformEffectAttribute;

					var manifest = new EffectModuleManifest {
						Module = module,
						Anchor = attribute.Anchor,
						Component = TransformComponent.Position,
						WorldSpace = attribute.UseWorldSpace,
						Function = positionEffect.GetPosition
					};
					manifests.Add(manifest);
				}
			}
			if (module is IRotationEffect rotationEffect) {
				foreach (var methodInfo in module.GetType().GetInterfaceMap(typeof(IRotationEffect)).TargetMethods) {
					var attribute = Attribute.GetCustomAttribute(methodInfo, typeof(TransformEffectAttribute)) as TransformEffectAttribute;

					var manifest = new EffectModuleManifest {
						Module = module,
						Anchor = attribute.Anchor,
						Component = TransformComponent.Rotation,
						WorldSpace = attribute.UseWorldSpace,
						Function = rotationEffect.GetRotation
					};
					manifests.Add(manifest);
				}
			}
			if (module is IScaleEffect scaleEffect) {
				foreach (var methodInfo in module.GetType().GetInterfaceMap(typeof(IScaleEffect)).TargetMethods) {
					var attribute = Attribute.GetCustomAttribute(methodInfo, typeof(TransformEffectAttribute)) as TransformEffectAttribute;

					var manifest = new EffectModuleManifest {
						Module = module,
						Anchor = attribute.Anchor,
						Component = TransformComponent.Rotation,
						WorldSpace = attribute.UseWorldSpace,
						Function = scaleEffect.GetScale
					};
					manifests.Add(manifest);
				}
			}
		}

		private void LoadModules() {
			var fieldInfos =
				from fieldInfo in typeof(FirstPersonEffectSystem).GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
				where fieldInfo.FieldType.IsSubclassOf(typeof(EffectModule))
				select fieldInfo;

			var modules = fieldInfos.Select(x => x.GetValue(this));
			foreach (EffectModule module in modules) {
				Add(module);
			}
		}
	}
}
