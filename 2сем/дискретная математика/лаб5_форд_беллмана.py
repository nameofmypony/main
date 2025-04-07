A = [
    [0, 6, float('inf'), 7],
    [float('inf'), 0, 5, 8],
    [float('inf'), -4, 0, float('inf')],
    [float('inf'), float('inf'), -3, 0]
]
minus = False
number = len(A)
start = 0
end = 2
dist = [float('inf')] * number
dist[start] = 0
for i in range(number - 1):
    for a in range(number):
        for b in range(number):
            if A[a][b] != 0:
                if dist[a] + A[a][b] < dist[b]:
                    dist[b] = dist[a] + A[a][b]
for a in range(number):
    for b in range(number):
        if A[a][b] != 0:
            if dist[a] + A[a][b] < dist[b]:
                print("есть отрицательный цикл")
                minus = True
                break
if not minus:
    if dist[end] == float('inf'):
        print(f"нет пути от {start} до {end}")
    else:
        print(f"длина кратчайшего пути от {start} до {end} равна {dist[end]}")
