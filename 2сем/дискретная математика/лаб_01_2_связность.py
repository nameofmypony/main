A = [
    [0, 1, 0, 0, 1],
    [1, 0, 0, 0, 1],
    [0, 0, 0, 1, 0],
    [0, 0, 1, 0, 0],
    [1, 1, 0, 0, 0]
]
n = len(A)
labels = [0] * n
current_label = 0
for i in range(n):
    if labels[i] == 0:
        current_label += 1
        labels[i] = current_label
        queue = [i]
        while queue:
            v = queue.pop(0)
            for u in range(n):
                if A[v][u] == 1:
                    if labels[u] == 0:
                        labels[u] = current_label
                        queue.append(u)
                    elif labels[u] != current_label:
                        old_label = labels[u]
                        for k in range(n):
                            if labels[k] == old_label:
                                labels[k] = current_label
print("кол-во компонент связности:", len(set(labels)))
