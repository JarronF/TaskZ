# TaskZ
A task management application that allows one to enter various tasks and subtasks for completion. Also allows adding comments to tasks.

#### Technology featured:
*	C#, ASP.NET RazorPages 
*	EntityFramework Core 
*	Code-First database migrations and the fluent API to create and configure the database and tables directly from code
*	ASP.NET identity to manage logins and access
*	Dependency Injection for Repositories and DbContext
*	Unit Test project for testing via xUnit and MOQ

### Task Board:
* Display list of tasks
* Clicking on the task line displays any sub-tasks
* Sub-tasks are only loaded from the DB once main task is clicked and partial view updates via AJAX

![TaskBoard](https://user-images.githubusercontent.com/68229225/121542483-77990c00-ca08-11eb-9cad-fcb783bb5f5c.png)


### Create / Edit Page:
![CreateEditTask](https://user-images.githubusercontent.com/68229225/121542499-79fb6600-ca08-11eb-8491-9b9365c8a993.png)


### TODO:
* Add Grid View option for Task Board page
* Add ability to edit individual comments
* Add "time spent" capture option per task
