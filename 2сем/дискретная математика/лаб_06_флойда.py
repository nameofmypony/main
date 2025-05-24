A = [
    [0, 6, float('inf'), 7],
    [float('inf'), 0, 5, 8],
    [float('inf'), -4, 0, float('inf')],
    [float('inf'), float('inf'), -3, 0]
]
number = len(A)
dist = [[A[a][b] for b in range(number)] for a in range(number)]
for i in range(number):
    for start in range(number):
        for end in range(number):
            if dist[start][i] != float('inf') and dist[i][end] != float('inf'):
                dist[start][end] = min(dist[start][end], dist[start][i] + dist[i][end])
print("матрица кратчайших путей:")
for start in range(number):
    for end in range(number):
        print(dist[start][end], end='\t')
    print()
