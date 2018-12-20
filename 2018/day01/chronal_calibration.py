from typing import List, Iterator

file = open('input.dat')

int_input = [int(str.strip(l, '\n')) for l in file]

def calibrate(data: list):
    return sum(data)

# assert calibrate([+1,+1,+1]) == 3 
# assert calibrate([+1,+1,-2]) == 0 
# assert calibrate([-1,-2,-3]) == -6 

print(calibrate(int_input))

def get_frequencies(frequencies: List[int], start :int = 0)-> Iterator[int]:
    yield start
    while True:
        for frecuency in frequencies:
            start += frecuency
            yield start

def calc_frecuency_twice(frequencies: List[int], start :int = 0):
    seen = set()
    for f in get_frequencies(frequencies, start):
        if(f in seen):
            return f
        else:
            seen.add(f)

# print(calc_frecuency_twice([1,-1]))
print(calc_frecuency_twice([3, 3, 4, -2, -4]))

print(calc_frecuency_twice([-6, 3, 8, 5, -6]))
print(calc_frecuency_twice([7, 7, -2, -7, -4]))
print(calc_frecuency_twice(int_input))




"""
Here are other examples:

+1, -1 first reaches 0 twice.
+3, +3, +4, -2, -4 first reaches 10 twice.
-6, +3, +8, +5, -6 first reaches 5 twice.
+7, +7, -2, -7, -4 first reaches 14 twice.

"""
