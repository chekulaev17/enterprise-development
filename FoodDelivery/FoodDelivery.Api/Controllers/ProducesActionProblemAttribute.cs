using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace FoodDelivery.Api.Controllers;

/// <summary>
/// Описывает дополнительный ответ у указанного наследуемого действия
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
internal sealed class ProducesActionProblemAttribute(string actionName, int statusCode)
    : Attribute, IControllerModelConvention
{
    public void Apply(ControllerModel controller)
    {
        var action = controller.Actions.Single(item => item.ActionName == actionName);
        action.Filters.Add(new ProducesResponseTypeAttribute(
            typeof(ProblemDetails), statusCode, "application/problem+json"));
    }
}
