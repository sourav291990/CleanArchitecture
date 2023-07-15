using NetArchTest.Rules;
using Shouldly;

namespace CleanArchitecture.tests
{
    public class ArchitectureTests
    {
        private const string DomainNamespace = "Domain";
        private const string ApplicationNamespace = "Application";
        private const string InfrastructureNamespace = "Infrastructure";
        private const string PersistenceNamespace = "Persistence";
        private const string PresentationNamespace = "Presentation";
        private const string WebNamespace = "Web";

        [Fact]
        public void Domain_Should_Not_HaveDependencyOnOtherProject()
        {
            //arrange
            var assembly = typeof(Domain.AssemblyReference).Assembly;

            var otherProjects = new[]
            {
            ApplicationNamespace, InfrastructureNamespace, PersistenceNamespace, PresentationNamespace, WebNamespace
            };

            //act
            var testResult = Types.InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAll(otherProjects)
                .GetResult();

            //assert
            testResult.IsSuccessful.ShouldBe(true);
        }

        [Fact]
        public void Application_Should_Not_HaveDependencyOnOtherProject()
        {
            //arrange
            var assembly = typeof(Application.AssemblyReference).Assembly;

            var otherProjects = new[]
            {
            InfrastructureNamespace, PersistenceNamespace, PresentationNamespace, WebNamespace
            };

            //act
            var testResult = Types.InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAll(otherProjects)
                .GetResult();

            //assert
            testResult.IsSuccessful.ShouldBe(true);
        }

        [Fact]
        public void Application_Should_HaveDependencyOnDomain()
        {
            //arrange
            var assembly = typeof(Application.AssemblyReference).Assembly;

            //act
            var testResult = Types.InAssembly(assembly)
                .Should()
                .HaveDependencyOn(DomainNamespace)
                .GetResult();

            //assert
            testResult.IsSuccessful.ShouldBe(true);
        }


        [Fact]
        public void Persistence_Should_Not_HaveDependencyOnOtherProject()
        {
            //arrange
            var assembly = typeof(Persistence.AssemblyReference).Assembly;

            var otherProjects = new[]
            {
            DomainNamespace, PresentationNamespace, WebNamespace, InfrastructureNamespace
            };

            //act
            var testResult = Types.InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAll(otherProjects)
                .GetResult();

            //assert
            testResult.IsSuccessful.ShouldBe(true);
        }


        [Fact]
        public void Persistence_Should_HaveDependencyOnApplicationProject()
        {
            //arrange
            var assembly = typeof(Persistence.AssemblyReference).Assembly;


            //act
            var testResult = Types.InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAll(ApplicationNamespace)
                .GetResult();

            //assert
            testResult.IsSuccessful.ShouldBe(true);
        }
    }
}