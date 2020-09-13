import math
from collections import namedtuple
Info = namedtuple('Info', ['weight', 'index', 'number'])

def closest(st):
    if st == "":
        return []

    data = []
    for i, number in enumerate(st.split()):
        data.append(Info(sum(int(c) for c in number), i, int(number)))
    
    data.sort()

    # for d in data:
    #     print(d)
    # print()
  
    results = []
    for a, b in zip(data, data[1:]):
        results.append((b.weight - a.weight, [a, b]))
    
    for res in sorted(results, key=lambda x: (x[0], x[1].weight)):
        print(res[0], list(res[1][0]), list(res[1][1]))
    
    # Sorting to find the smallest diff, weight, indicies (in that order) as requested.
    # Get the smallest pair and transform the namedtuples to lists of its property values.
    return [list(x) for x in sorted(results, key=lambda x: (x[0], x[1].weight))[0][-1]]

answer = closest("80 71 62 53")
print("\nresult:", answer)

assert answer == [[8, 0, 80], [8, 1, 71]]