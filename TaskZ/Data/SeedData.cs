using TaskZ.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace TaskZ.Data
{
    public static class SeedData
    {
        public static ModelBuilder Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = 1,
                    FirstName = "Jarron",
                    LastName = "Futter",
                    UserName = "JFutter",
                    NormalizedUserName = "JFUTTER",
                    Email = "jarronfutter@gmail.com",
                    NormalizedEmail = "JARRONFUTTER@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAENvI6oAPbg2lkU3a6HGpFRR8dsmQkuVRRSFoS0pQEdTa1mfrQpEEHX0oAl7I3whA9w==",
                    SecurityStamp = "TMGKLNJAYIDTFMHNYDEWUO5K47W5VRCU",
                    ConcurrencyStamp = "b74678a8-3a1f-4285-ade7-e45e2eb3f14e",
                    BirthDate = DateTime.Parse("1982/05/03 10:00:00")
                },
                 new ApplicationUser
                 {
                     Id = 2,
                     FirstName = "Sue",
                     LastName = "Smith",
                     UserName = "SueS",
                     NormalizedUserName = "SUES",
                     Email = "sue@smith.com",
                     NormalizedEmail = "SUE@SMITH.COM",
                     EmailConfirmed = true,
                     PasswordHash = "AQAAAAEAACcQAAAAEOTYbjAxBbT3Ah05q2oP4ksoBndwrHNVu10FCosT1lAzO/Hrv2Cw/knZ7QiWXNd0ig==",
                     SecurityStamp = "J3Z5NW2OTUDUTBFKZKSH5FFMGSKXNEFC",
                     ConcurrencyStamp = "1f750e4f-100b-43dc-a0ae-4459f8d28d81",
                     BirthDate = DateTime.Parse("1989/06/20 10:00:00")
                 }
            );

            modelBuilder.Entity<TaskItem>().HasData(
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
                    ParentID = 1,
                    DueDate = DateTime.Parse("2021/06/15 10:00:00"),
                    Title = "Find Pinky",
                    ShortDescription = "Pinky can do the hard work",
                    AssignedUserId = 2
                },
                new TaskItem
                {
                    Id = 3,
                    ParentID = 1,
                    DueDate = DateTime.Parse("2021/06/15 10:00:00"),
                    Title = "Find Brain",
                    ShortDescription = "Brain will control the operation",
                    AssignedUserId = 1
                }
            );

            modelBuilder.Entity<TaskComment>().HasData(
               new TaskComment
               {
                   Id = 1,
                   UserId = 1,
                   Comment = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
                             "In tincidunt justo vulputate tristique ultrices. Praesent nec auctor erat. Ut ante ex, rhoncus id felis vel, porta molestie massa. " +
                             "Sed malesuada pharetra sapien sed laoreet. Aenean in diam nec sapien lacinia cursus sed ultrices eros. Duis et sagittis diam, eu condimentum odio. " +
                             "Integer convallis nibh feugiat congue tincidunt. Vestibulum bibendum condimentum erat. Praesent sit amet pretium leo, sit amet interdum eros. " +
                             "Nam fringilla pellentesque finibus.",
                   CommentDate = DateTime.Now,
                   ParentId = 1                   
               }
            );
            return modelBuilder;
        }
    }
}

