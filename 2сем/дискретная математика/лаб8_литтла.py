A = [
    [float('inf'), 4, 5, 7, 5],
    [8, float('inf'), 5, 6, 6],
    [3, 5, float('inf'), 9, 6],
    [3, 5, 6, float('inf'), 2],
    [6, 2, 3, 8, float('inf')],
]
n = len(A)
best_path = []
best_cost = float('inf')
stack: list = []
for start_vertex in range(n):
    stack.append(([start_vertex], 0))
    while stack:
        path, current_cost = stack.pop()
        if len(path) == n:
            if A[path[-1]][path[0]] != float('inf'):
                total_cost = current_cost + A[path[-1]][path[0]]
                if total_cost < best_cost:
                    best_cost = total_cost
                    best_path = path[:]
            continue
        for vertex in range(n):
            if vertex not in path and A[path[-1]][vertex] != float('inf'):
                new_cost = current_cost + A[path[-1]][vertex]
                if new_cost < best_cost:
                    stack.append((path + [vertex], new_cost))
if best_path:
    for i in range(len(best_path)):
        best_path[i] += 1
    contur = best_path + [best_path[0]]
    print("гамильтонов контур:", contur)
    print("его длина:", best_cost)
else:
    print("гамильтонов контур не найден")
