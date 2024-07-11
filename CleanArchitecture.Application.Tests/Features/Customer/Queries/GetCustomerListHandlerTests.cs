namespace CleanArchitecture.Application.Tests.Features.Customer.Queries;

using Moq;
using Shouldly;
using AutoMapper;
using CleanArchitecture.Application.Mappings;
using CleanArchitecture.Application.Tests.Mocks;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Features.Customer.Queries.DTOs;
using CleanArchitecture.Application.Contracts.Infrastructure.Logging;
using CleanArchitecture.Application.Features.Customer.Queries.Requests;
using CleanArchitecture.Application.Features.Customer.Queries.RequestHandlers;

public class GetCustomerListHandlerTests
{
    private readonly Mock<ICustomerRepository> _mockCustomerRepository;
    private readonly IMapper _mapper;
    private readonly Mock<IAppLogger<GetCustomerListHandler>> _appLogger;

    public GetCustomerListHandlerTests()
    {
        _mockCustomerRepository = MockCustomerRepository.GetMockCustomerTypeRepository();
        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<CustomerProfile>();
        });
        _mapper = mapperConfig.CreateMapper();
        _appLogger = new Mock<IAppLogger<GetCustomerListHandler>>();
    }

    [Fact]
    public async Task GetAllCustomerTest()
    {
        // arrange
        var handler = new GetCustomerListHandler(_mapper, _mockCustomerRepository.Object, _appLogger.Object);

        // act
        var result = await handler.Handle(new GetCustomerList(), CancellationToken.None);

        // assert
        result.ShouldBeOfType<List<CustomerDto>>();
        result.Count.ShouldBe(1);
    }
}
