def common_chr(box1: str, box2: str):
    common = ''
    for i in range(len(box1)):
        if ord(box1[i]) - ord(box2[i]) == 0:
            common+=box1[i]

    return common

def common_letters(boxIds: list):
    best = ''
    for box1 in boxIds:
        for box2 in boxIds:
            if box1 != box2:
                result = common_chr(box1, box2)
                if len(result)>len(best):
                    best = result
    
    return best


boxIdsTest = [
    "abcde",
    "fghij",
    "klmno",
    "pqrst",
    "fguij",
    "axcye",
    "wvxyz",
]

assert common_chr("fguij", "fghij") == 'fgij'
assert common_letters(boxIdsTest) == 'fgij'

boxIds = []
with open('./input.txt') as file:
    for line in file:
        boxIds.append(line.strip())

print(common_letters(boxIds))