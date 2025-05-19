A = [
    [0, 1, 0, 0, 1],
    [1, 0, 0, 0, 1],
    [0, 0, 0, 1, 0],
    [0, 0, 1, 0, 0],
    [1, 1, 0, 0, 0]
]
n = len(A)
visited = [False] * n
count = 0
for v in range(n):
    if not visited[v]:
        count += 1
        queue = [v]
        visited[v] = True
        while queue:
            current = queue.pop(0)
            for neighbor in range(n):
                if A[current][neighbor] == 1 and not visited[neighbor]:
                    visited[neighbor] = True
                    queue.append(neighbor)
print("кол-во компонент связности:", count)
