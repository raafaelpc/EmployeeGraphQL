using EmployeeGraphQL.Data;
using EmployeeGraphQL.Models;

namespace EmployeeGraphQL.GraphQL.Queries
{
    public class Query
    {
        public IQueryable<Employee> getEmployees([Service] EmployeeContext context) =>
            context.Employees;
    }
}
