using Microsoft.AspNetCore.Mvc.ApplicationModels;

public class KebabCaseRouteConvention : IApplicationModelConvention
{
    public void Apply(ApplicationModel application)
    {
        foreach (var controller in application.Controllers)
        {
            foreach (var selector in controller.Selectors)
            {
                if (selector.AttributeRouteModel != null &&
                    selector.AttributeRouteModel.Template != null &&
                    selector.AttributeRouteModel.Template.Contains("[controller]"))
                {
                    var controllerName = controller.ControllerName;
                    var kebabCaseName = ConvertToKebabCase(controllerName);
                    selector.AttributeRouteModel.Template = 
                        selector.AttributeRouteModel.Template.Replace("[controller]", kebabCaseName);
                }
            }
        }
    }

    private string ConvertToKebabCase(string input)
    {
        return string.Concat(input.Select((ch, i) =>
            i > 0 && char.IsUpper(ch) ? "-" + char.ToLower(ch) : char.ToLower(ch).ToString()));
    }
}
