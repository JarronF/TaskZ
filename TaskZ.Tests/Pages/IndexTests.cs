using System;
using Xunit;
using TaskZ.Services;
using System.Collections.Generic;
using Autofac.Extras.Moq;
using TaskZ.Models;
using System.Threading.Tasks;
using TaskZ.Pages;
using Microsoft.AspNetCore.Mvc;
using TaskZ.Data;
using Moq;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace TaskZ.Tests.Pages
{
    public class IndexTests
    {
        private Mock<ITaskItemService> taskItemService_Mock;
        private Mock<ApplicationDbContext> db_Mock;
        //private Mock<ILogger<IndexModel>> loggerMock;


        public IndexTests()
        {
            //taskItemService_Mock = new Mock<ITaskItemService>();
            ////loggerMock = new Mock<ILogger<IndexModel>>();            

            //taskItemService_Mock
            //    .Setup(x => x.GetSubTasks(1))
            //    .Returns(Task.FromResult(GetSampleSubTasks()));

            //db_Mock = new Mock<ApplicationDbContext>();
        }
        [Fact]
        public async void OnGetSubTasksPartialAsync_ShouldReturnPartialViewResult()
        {
            //using var mock = AutoMock.GetLoose();
            //var svc = mock.Mock<ITaskItemService>()
            //    .Setup(x => x.GetSubTasks(1))
            //    .Returns(Task.FromResult(GetSampleSubTasks()));

            //var cls = mock.Create<IndexModel>();
            //var actual = await cls.OnGetSubTasksPartialAsync(1);

            //Assert.IsType<PartialViewResult>(actual.ViewData.Model);
            //Assert.Equal("MyPartialView", actual.ViewName);
        }

        private List<TaskItem> GetSampleSubTasks()
        {
            return new List<TaskItem>
            {
                new TaskItem
                {
                    Id = 2,
                    ParentID = 1, //An existing parentId indicates a subtask
                    DueDate = DateTime.Parse("2021/06/15 10:00:00"),
                    Title = "111Find Pinky",
                    ShortDescription = "Pinky can do the hard work",
                    AssignedUserId = 2
                },
                new TaskItem
                {
                    Id = 3,
                    ParentID = 1, //An existing parentId indicates a subtask
                    DueDate = DateTime.Parse("2021/06/15 10:00:00"),
                    Title = "222Find Brain",
                    ShortDescription = "Brain will control the operation",
                    AssignedUserId = 1
                }
            };

        }
    }
}
