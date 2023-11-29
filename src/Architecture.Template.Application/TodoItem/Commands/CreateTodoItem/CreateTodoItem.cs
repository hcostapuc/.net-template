﻿namespace Application.TodoItem.Commands.CreateTodoItem;

public sealed record CreateTodoItemCommand(Guid ListId,
                                    string? Title) : IRequest<Guid>;