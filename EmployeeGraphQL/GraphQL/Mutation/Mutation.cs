using EmployeeGraphQL.Data;
using EmployeeGraphQL.Models;
using HotChocolate;

namespace EmployeeGraphQL.GraphQL.Mutations
{
    public class Mutation
    {
        public async Task<Employee> addEmployee([Service] EmployeeContext context, Employee employee)
        {
            //employee.Id = 0;
            context.Employees.Add(employee);
            await context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> updateEmployee([Service] EmployeeContext context, Employee employee)
        {
            context.Employees.Update(employee);
            await context.SaveChangesAsync();
            return employee;
        }

        public async Task<bool> deleteEmployee([Service] EmployeeContext context, int id)
        {
            var employee = await context.Employees.FindAsync(id);
            if (employee == null)
            {
                return false;
            }

            context.Employees.Remove(employee);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
