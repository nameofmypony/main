A = [
    [0, 40, 0, 35, 0, 0],
    [0, 0, 60, 0, 0, 20],
    [0, 0, 0, 30, 0, 45],
    [0, 0, 0, 0, 50, 0],
    [0, 25, 0, 0, 0, 30],
    [0, 0, 0, 0, 0, 0]
]
start = 0
finish = 5
n = len(A)
result = 0
while True:
    parent = [-1] * n
    parent[start] = -2
    queue = [start]
    found = False
    while queue and not found:
        u = queue.pop(0)
        for v in range(n):
            if parent[v] == -1 and A[u][v] > 0:
                parent[v] = u
                if v == finish:
                    found = True
                    break
                queue.append(v)
    if not found:
        break
    flow = float('inf')
    v = finish
    while v != start:
        u = parent[v]
        flow = min(flow, A[u][v])
        v = u
    v = finish
    while v != start:
        u = parent[v]
        A[u][v] -= flow
        A[v][u] += flow
        v = u
    result += flow
print("максимальный поток:", result)
