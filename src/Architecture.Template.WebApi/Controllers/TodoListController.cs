﻿using Application.TodoList.Commands.CreateTodoList;
using Application.TodoList.Commands.DeleteTodoList;
using Application.TodoList.Commands.UpdateTodoList;
using Application.TodoList.Queries.GetTodo;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common;

namespace WebApi.Controllers;

public class TodoListController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<TodosVm>> GetAsync() =>
        await Sender.Send(new GetTodoQuery());

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateAsync(CreateTodoListCommand command) =>
        await Sender.Send(command);

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateAsync(Guid id, UpdateTodoListCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Sender.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAsync(Guid id)
    {
        await Sender.Send(new DeleteTodoListCommand(id));

        return NoContent();
    }
}
