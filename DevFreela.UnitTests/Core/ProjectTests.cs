using DevFreela.Core.Entities;
using DevFreela.Core.Enums;
using FluentAssertions;

namespace DevFreela.UnitTests.Core
{
    public class ProjectTests
    {
        [Fact]
        public void ProjectIsCreated_Start_Success()
        {
            // Arrange
            var project = new Project("Projeto A", "Descrição do Projeto", 1, 2, 10000);

            // Act
            project.Start();

            // Assert
            Assert.Equal(ProjectStatusEnum.InProgress, project.Status);

            project.Status.Should().Be(ProjectStatusEnum.InProgress);

            Assert.NotNull(project.StartedAt);

            project.StartedAt.Should().BeNull();

            Assert.True(project.Status == ProjectStatusEnum.InProgress);
            Assert.False(project.StartedAt is null);
        }

        [Fact]
        public void ProjectIsInInvalidState_Start_ThrowsException()
        {
            // Arrange
            var project = new Project("Projeto A", "Descrição do Projeto", 1, 2, 10000);
            project.Start();

            // Act + Assert
            Action? start = project.Start;

            var exception = Assert.Throws<InvalidOperationException>(start);
            Assert.Equal(Project.INVALID_STATE_MESSAGE, exception.Message);

            start.Should()
                .Throw<InvalidOperationException>()
                .WithMessage(Project.INVALID_STATE_MESSAGE);
        }
    }
}