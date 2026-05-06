using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace EcommerceRoutingMVC.Constraints
{
    public class CategoryConstraint : IRouteConstraint
    {
        private readonly string[] validCategories =
        {
            "electronics",
            "fashion",
            "books"
        };

        public bool Match(HttpContext? httpContext,
            IRouter? route,
            string routeKey,
            RouteValueDictionary values,
            RouteDirection routeDirection)
        {
            if (values.TryGetValue(routeKey, out var value))
            {
                return validCategories.Contains(value!.ToString()!.ToLower());
            }

            return false;
        }
    }
}