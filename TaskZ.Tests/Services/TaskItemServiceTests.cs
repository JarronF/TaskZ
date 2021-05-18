using System;
using Xunit;
using TaskZ.Services;
using System.Collections.Generic;
using Autofac.Extras.Moq;
using TaskZ.Models;
using System.Threading.Tasks;
using TaskZ.Repositories;

namespace TaskZ.Tests
{
    public class TaskItemServiceTests
    {
        [Fact]
        public async void GetHighLevelTasks_ShouldReturnAllTasks()
        {
            using var mock = AutoMock.GetLoose();
            mock.Mock<ITaskItemRepository>()
                .Setup(x => x.GetTasksByParentId(null))
                .Returns(GetSampleHighLevelTasks());

            var cls = mock.Create<TaskItemService>();
            var expected = await GetSampleHighLevelTasks();
            var actual = await cls.GetHighLevelTasks();

            Assert.NotNull(actual);
            Assert.Equal(expected.Count, actual.Count);

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.Equal(expected[i].Title, actual[i].Title);
            }
        }
        [Fact]
        public async void GetTaskItemById_ShouldReturnOneTask()
        {
            using var mock = AutoMock.GetLoose();
            mock.Mock<ITaskItemRepository>()
                .Setup(x => x.GetTaskItemById(13))
                .Returns(GetSampleTaskItem());

            var cls = mock.Create<TaskItemService>();
            var expected = await GetSampleTaskItem();
            var actual = await cls.GetTaskItemById(13);

            Assert.NotNull(actual);
            Assert.Equal(expected.Id, actual.Id);
        }

        private async Task<TaskItem> GetSampleTaskItem()
        {
            return await Task.Run(() => new TaskItem
            {
                Id = 13,
                DueDate = DateTime.Parse("2021/06/15 10:00:00"),
                Title = "Task Number 13",
                ShortDescription = "Sample task number 13 description",
                AssignedUserId = 1
            });
        }

        private async Task<List<TaskItem>> GetSampleHighLevelTasks()
        {
            return await Task.Run(() => new List<TaskItem>
            {
                 new TaskItem
                {
                    Id = 1,
                    DueDate = DateTime.Parse("2021/06/15 10:00:00"),
                    Title = "Try to take over the world",
                    ShortDescription = "We need to attempt to control the entire world. Starting from A proceeding to Z",
                    AssignedUserId = 1
                },
                new TaskItem
                {
                    Id = 2,
                    //ParentID = 1, -- No parentID should be set for high level tasks
                    DueDate = DateTime.Parse("2021/06/15 10:00:00"),
                    Title = "Find Pinky",
                    ShortDescription = "Pinky can do the hard work",
                    AssignedUserId = 2
                },
                new TaskItem
                {
                    Id = 3,
                    //ParentID = 1,
                    DueDate = DateTime.Parse("2021/06/15 10:00:00"),
                    Title = "Find Brain",
                    ShortDescription = "Brain will control the operation",
                    AssignedUserId = 1
                }
            });
        }
    }
}
