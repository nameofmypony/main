A = [
    [0, 0, 0, 1, 0],
    [0, 1, 0, 1, 0],
    [0, 0, 0, 1, 0],
    [0, 0, 1, 1, 0],
    [0, 0, 0, 0, 0]
]
start = (0, 0)
end = (3, 4)
print("матрица препятствий:")
for row in A:
    print(row)
print(f"начальная точка: {start}")
print(f"конечная точка: {end}")
error = False
rows = len(A)
if rows == 0:
    print("матрица пуста")
    error = True
cols = len(A[0])
if (start[0] < 0 or start[0] >= rows or start[1] < 0 or start[1] >= cols):
    print("cтарт вне границ")
    error = True
if (end[0] < 0 or end[0] >= rows or end[1] < 0 or end[1] >= cols):
    print("финиш вне границ")
    error = True
if A[start[0]][start[1]] == 1:
    print("старт на препятствии")
    error = True
if A[end[0]][end[1]] == 1:
    print("финиш на препятствии")
    error = True
distances = [[-1 for _ in range(cols)] for _ in range(rows)]
distances[start[0]][start[1]] = 0
queue = [start]
directions = [(-1, 0), (1, 0), (0, -1), (0, 1)]
while queue:
    x, y = queue.pop(0)
    if (x, y) == end:
        break
    for a, b in directions:
        new_x, new_y = x + a, y + b
        if (0 <= new_x < rows and 0 <= new_y < cols and A[new_x][new_y] == 0 and distances[new_x][new_y] == -1):
            distances[new_x][new_y] = distances[x][y] + 1
            queue.append((new_x, new_y))
if not error:
    print("матрица расстояний:")
    for row in distances:
        print(row)
if distances[end[0]][end[1]] == -1:
    print("конечная точка недостижима")
else:
    print(f"длина кратчайшего пути: {distances[end[0]][end[1]]} шагов")
