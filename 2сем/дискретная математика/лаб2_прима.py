A = [
    [0, 1, 3, float('inf')],
    [1, 0, 1, 4],
    [3, 1, 0, 2],
    [float('inf'), 4, 2, 0]
]
number = len(A)
selected = [False] * number
selected[0] = True
tree = 0
for vertex in range(number - 1):
    min_weight = float('inf')
    x = y = 0
    for a in range(number):
        if selected[a]:
            for b in range(number):
                if not selected[b] and A[a][b] < min_weight:
                    min_weight = A[a][b]
                    x = a
                    y = b
    selected[y] = True
    tree += min_weight
print("минимальный вес дерева:", tree)
