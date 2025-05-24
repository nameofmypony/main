def components(A):
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
                    if A[current][neighbor] != float('inf') and current != neighbor and not visited[neighbor]:
                        visited[neighbor] = True
                        queue.append(neighbor)
    return count
def find_bridges(A):
    n = len(A)
    bridges = []
    original_components = components(A)
    for u in range(n):
        for v in range(u + 1, n):
            if A[u][v] != float('inf'):
                original_weight = A[u][v]
                A[u][v] = A[v][u] = float('inf')
                if components(A) > original_components:
                    bridges.append((u, v, original_weight))
                A[u][v] = A[v][u] = original_weight
    return bridges
A = [
    [0, 1, float('inf'), float('inf')],
    [1, 0, 2, float('inf')],
    [float('inf'), 2, 0, 3],
    [float('inf'), float('inf'), 3, 0]
]
bridges = find_bridges(A)
if bridges:
    print("мосты графа:")
    for bridge in bridges:
        print(f"ребро {bridge[0]}-{bridge[1]} (вес {bridge[2]})")
else:
    print("нет")
