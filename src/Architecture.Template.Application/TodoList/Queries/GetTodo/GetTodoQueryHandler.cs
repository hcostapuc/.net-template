﻿using Domain.Enums;
using Domain.Interfaces.Repository;

namespace Application.TodoList.Queries.GetTodo;
public class GetTodosQueryHandler : IRequestHandler<GetTodoQuery, TodosVm>
{
    private readonly IVehicleRepository _todoListRepository;
    private readonly IMapper _mapper;

    public GetTodosQueryHandler(IVehicleRepository todoListRepository, IMapper mapper)
    {
        _todoListRepository = todoListRepository ?? throw new ArgumentNullException(nameof(todoListRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<TodosVm> Handle(GetTodoQuery request, CancellationToken cancellationToken) =>
         new TodosVm
         {
             Lists = _mapper.Map<IList<TodoListDto>>(await _todoListRepository.SelectAllAsync(cancellationToken: cancellationToken))
         };
}