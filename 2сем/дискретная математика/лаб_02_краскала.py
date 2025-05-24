A = [
    [0, 1, 3, float('inf')],
    [1, 0, 1, 4],
    [3, 1, 0, 2],
    [float('inf'), 4, 2, 0]
]
number = len(A)
edges = []
for a in range(number):
    for b in range(a + 1, number):
        if A[a][b] < float('inf'):
            edges.append((A[a][b], a, b))
edges.sort()
parent = list(range(number))
tree = 0


def find(a):
    if parent[a] != a:
        parent[a] = find(parent[a])
    return parent[a]


for weight, a, b in edges:
    root_a = find(a)
    root_b = find(b)
    if root_a != root_b:
        parent[root_b] = root_a
        tree += weight
print("минимальный вес дерева:", tree)
