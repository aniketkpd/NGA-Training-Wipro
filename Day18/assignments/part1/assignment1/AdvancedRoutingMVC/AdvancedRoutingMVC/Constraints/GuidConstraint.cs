using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace AdvancedRoutingMVC.Constraints
{
    public class GuidConstraint : IRouteConstraint
    {
        public bool Match(HttpContext? httpContext,
            IRouter? route,
            string routeKey,
            RouteValueDictionary values,
            RouteDirection routeDirection)
        {
            if (values.TryGetValue(routeKey, out var value))
            {
                return Guid.TryParse(value?.ToString(), out _);
            }

            return false;
        }
    }
}