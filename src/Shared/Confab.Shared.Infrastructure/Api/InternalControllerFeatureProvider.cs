using System;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace Confab.Shared.Infrastructure.Api;

internal class InternalControllerFeatureProvider : ControllerFeatureProvider
{
    protected override bool IsController(TypeInfo typeInfo)
    {
        return typeInfo.IsClass && !typeInfo.IsAbstract && !typeInfo.ContainsGenericParameters &&
               !typeInfo.IsDefined(typeof(NonControllerAttribute)) &&
               (typeInfo.Name.EndsWith("Controller", StringComparison.OrdinalIgnoreCase) ||
                typeInfo.IsDefined(typeof(ControllerAttribute)));
    }
}