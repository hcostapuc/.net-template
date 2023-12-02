﻿using Domain.Interfaces.Repository;

namespace Application.TodoList.Commands.CreateTodoList;
public class CreateTodoListCommandHandler : IRequestHandler<CreateTodoListCommand, Guid>
{
    private readonly IVehicleRepository _todoListRepository;

    public CreateTodoListCommandHandler(IVehicleRepository todoListRepository) =>
        _todoListRepository = todoListRepository ?? throw new ArgumentNullException(nameof(todoListRepository));

    public async Task<Guid> Handle(CreateTodoListCommand request, CancellationToken cancellationToken)
    {
        var entity = new TodoListEntity
        {
            Title = request.Title
        };

        await _todoListRepository.InsertAsync(entity, cancellationToken);

        return entity.Id;
    }
}