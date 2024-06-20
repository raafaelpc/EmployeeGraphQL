using EmployeeGraphQL.Models;
using HotChocolate.Types;

namespace EmployeeGraphQL.GraphQL.Types
{
    public class EmployeeType : ObjectType<Employee>
    {
        protected override void Configure(IObjectTypeDescriptor<Employee> descriptor)
        {
            descriptor.Description("Represents an employee.");
            //descriptor.Field(e => e.Id).Ignore();
        }
    }
}
