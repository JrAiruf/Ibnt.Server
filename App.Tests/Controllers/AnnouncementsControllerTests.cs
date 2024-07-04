using App.Application.Dtos.AnnouncementEntity;
using App.Application.Interfaces;
using App.Domain.Entities.Announcement;
using App.Domain.Exceptions;
using App.Tests.Mocks.AnnouncementMocks;
using Ibnt.Server.Controllers;
using Microsoft.AspNetCore.Http.HttpResults;
using Moq;

namespace App.Tests.Controllers
{
    public class AnnouncementsControllerTests
    {
        private readonly Mock<IAnnouncementsRepository> _repositoryMock;
        private readonly AnnouncementsController _controller;
        public AnnouncementsControllerTests()
        {
            _repositoryMock = new Mock<IAnnouncementsRepository>();
            _controller = new AnnouncementsController(_repositoryMock.Object);
        }


        [Fact]
        public async Task Should_Fail_To_Create_A_New_Announcement_Due_To_Invalid_Data()
        {
            _repositoryMock.Setup(r => r.Create(It.IsAny<CreateAnnouncementDto>()))
                           .ReturnsAsync(Tuple.Create<AppException?, AnnouncementEntity?>
                           (
                               AnnouncementMocks.annoucementException, null)
                           );

            var result = await _controller.Create(AnnouncementMocks.announcementDto);
            _repositoryMock.Verify((r) => r.Create(AnnouncementMocks.announcementDto), Times.Once());
            Assert.NotNull(result);
            Assert.IsType<BadRequest<string>>(result.Result);
        }

        [Fact]
        public async Task Should_Return_A_Status_Code_201_And_An_Announcement_Dto_Object()
        {
            _repositoryMock.Setup(r => r.Create(It.IsAny<CreateAnnouncementDto>()))
                           .ReturnsAsync(Tuple.Create<AppException?, AnnouncementEntity?>
                           (
                               null, AnnouncementMocks.announcement)
                           );

            var result = await _controller.Create(AnnouncementMocks.announcementDto);
            _repositoryMock.Verify((r) => r.Create(AnnouncementMocks.announcementDto), Times.Once());
            Assert.NotNull(result);
            Assert.IsType<Results<BadRequest<string>, Created<AnnouncementDto>>>(result);
            Assert.IsType<Created<AnnouncementDto>>(result.Result);

        }
        
        [Fact]
        public async Task Should_Return_A_Status_Code_201_And_A_List_Of_Announcement_Dto_Object()
        {
            _repositoryMock.Setup(r => r.CreateManyAsync(It.IsAny<List<CreateAnnouncementDto>>()))
                           .ReturnsAsync(Tuple.Create<AppException?, List<AnnouncementEntity>?>
                           (
                               null, AnnouncementMocks.list)
                           );

            var result = await _controller.CreateManyAsync(AnnouncementMocks.creationList);
            _repositoryMock.Verify((r) => r.CreateManyAsync(AnnouncementMocks.creationList), Times.Once());
            Assert.NotNull(result);
            Assert.IsType<Results<BadRequest<string>, Created<List<AnnouncementDto>>>>(result);
            Assert.IsType<Created<List<AnnouncementDto>>>(result.Result);

        }

        [Fact]
        public async Task Should_Return_A_List_Of_Announcement_Entities()
        {
            _repositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(AnnouncementMocks.list);

            var result = await _controller.GetAllAsync();
            _repositoryMock.Verify((r) => r.GetAllAsync(), Times.Once());

            Assert.NotNull(result);
            Assert.IsType<Results<BadRequest<string>, Ok<List<AnnouncementDto>>>>(result);
            Assert.IsType<Ok<List<AnnouncementDto>>>(result.Result);
        }

        [Fact]
        public async Task Should_Return_Not_Found_To_The_Given_Id()
        {
            Guid id = Guid.NewGuid();
            _repositoryMock.Setup(r => r.GetByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync(Tuple.Create<AppException?, AnnouncementEntity?>
                (
                    new AnnouncementException("Item não encontrado."), null)
                );
            var result = await _controller.GetByIdAsync(id);
            _repositoryMock.Verify((r) => r.GetByIdAsync(id), Times.Once());

            Assert.NotNull(result);
            Assert.IsType<Results<NotFound<string>, Ok<AnnouncementDto>>>(result);
            Assert.IsType<NotFound<string>>(result.Result);
        }

        [Fact]
        public async Task Should_Return_Ok_Status_With_Announcement_Dto_Object()
        {
            Guid id = Guid.NewGuid();
            _repositoryMock.Setup(r => r.GetByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync(Tuple.Create<AppException?, AnnouncementEntity?>
                (
                    null, AnnouncementMocks.announcement)
                );
            var result = await _controller.GetByIdAsync(id);
            _repositoryMock.Verify((r) => r.GetByIdAsync(id), Times.Once());

            Assert.NotNull(result);
            Assert.IsType<Results<NotFound<string>, Ok<AnnouncementDto>>>(result);
            Assert.IsType<Ok<AnnouncementDto>>(result.Result);
        }

        [Fact]
        public async Task Should_Return_Bad_Request_Status_Due_To_Fail_Updating()
        {
            Guid id = Guid.NewGuid();
            _repositoryMock.Setup(r => r.UpdateAsync(id, It.IsAny<UpdateAnnouncementDto>()))
                           .ReturnsAsync(Tuple.Create<AppException?, AnnouncementEntity?>
                           (
                               new AnnouncementException("Erro ao Atualizar."), null)
                           );

            var result = await _controller.UpdateAsync(id, AnnouncementMocks.updateDto);
            _repositoryMock.Verify((r) => r.UpdateAsync(id, AnnouncementMocks.updateDto), Times.Once());

            Assert.NotNull(result);
            Assert.IsType<Results<BadRequest<string>, Ok<AnnouncementDto>>>(result);
            Assert.IsType<BadRequest<string>>(result.Result);
        }

        [Fact]
        public async Task Should_Return_Ok_Status_With_An_Updated_Announcement_Dto()
        {
            Guid id = Guid.NewGuid();
            _repositoryMock.Setup(r => r.UpdateAsync(It.IsAny<Guid>(), It.IsAny<UpdateAnnouncementDto>()))
                           .ReturnsAsync(Tuple.Create<AppException?, AnnouncementEntity?>
                           (
                               null, AnnouncementMocks.announcement)
                           );

            var result = await _controller.UpdateAsync(id, AnnouncementMocks.updateDto);
            _repositoryMock.Verify((r) => r.UpdateAsync(id, AnnouncementMocks.updateDto), Times.Once());

            Assert.NotNull(result);
            Assert.IsType<Results<BadRequest<string>, Ok<AnnouncementDto>>>(result);
            Assert.IsType<Ok<AnnouncementDto>>(result.Result);
        }

        [Fact]
        public async Task Should_Return_Not_Found_Status_Due_To_Fail_Deleting()
        {
            Guid id = Guid.NewGuid();
            _repositoryMock.Setup(r => r.DeleteAsync(id))
                           .ReturnsAsync(Tuple.Create<AppException?, Guid?>
                           (
                               new AnnouncementException("Erro ao Deletar."), null)
                           );

            var result = await _controller.DeleteAsync(id);
            _repositoryMock.Verify((r) => r.DeleteAsync(id), Times.Once());

            Assert.NotNull(result);
            Assert.IsType<Results<NotFound<string>, Ok<Guid>>>(result);
            Assert.IsType<NotFound<string>>(result.Result);
        }

        [Fact]
        public async Task Should_Return_Ok_Status_With_Id_Of_Deleted_Announcement()
        {
            Guid id = Guid.NewGuid();
            _repositoryMock.Setup(r => r.DeleteAsync(id))
                           .ReturnsAsync(Tuple.Create<AppException?, Guid?>
                           (
                               null, id)
                           );

            var result = await _controller.DeleteAsync(id);
            _repositoryMock.Verify((r) => r.DeleteAsync(id), Times.Once());

            Assert.NotNull(result);
            Assert.IsType<Results<NotFound<string>, Ok<Guid>>>(result);
            Assert.IsType<Ok<Guid>>(result.Result);
        }
    }
}
