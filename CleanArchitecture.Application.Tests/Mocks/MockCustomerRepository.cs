namespace CleanArchitecture.Application.Tests.Mocks;

using Moq;
using CleanArchitecture.Domain.Entities.Customer;
using CleanArchitecture.Application.Contracts.Persistence;

internal class MockCustomerRepository
{
    internal static Mock<ICustomerRepository> GetMockCustomerTypeRepository()
    {
        var guid = Guid.NewGuid();
        var customers = new List<Customer>
        {
            new("TestFirstName","TestLastName") { Id = guid }
        };

        var mockRepo = new Mock<ICustomerRepository>();
        mockRepo.Setup(x => x.GetAllAsync()).ReturnsAsync(customers);
        mockRepo.Setup(x => x.GetAsync(guid)).ReturnsAsync(customers[0]);
        mockRepo.Setup(x => x.AddAsync(It.IsAny<Customer>())).Returns((Customer customer) =>
        {
            customers.Add(customer);
            return Task.CompletedTask;
        });

        return mockRepo;
    }
}
