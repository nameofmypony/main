A = [
    [0, 10, 0, 5, 0],
    [0, 0, 1, 2, 0],
    [0, 0, 0, 0, 3],
    [0, 3, 9, 0, 2],
    [0, 0, 4, 6, 0]
]
number = len(A)
start = 0
end = 2
dist = [float('inf')] * number
dist[start] = 0
visited = [False] * number
for vertex in range(number):
    min_dist = float('inf')
    min_index = -1
    for a in range(number):
        if not visited[a] and dist[a] < min_dist:
            min_dist = dist[a]
            min_index = a
    visited[min_index] = True
    for a in range(number):
        if A[min_index][a] > 0 and not visited[a]:
            new_dist = dist[min_index] + A[min_index][a]
            if new_dist < dist[a]:
                dist[a] = new_dist
if dist[end] == float('inf'):
    print(f"нет пути от {start} до {end}")
else:
    print(f"длина кратчайшего пути от {start} до {end} равна {dist[end]}")
