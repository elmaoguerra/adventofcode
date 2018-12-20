def count_letters(boxId:str):
    dictCount = dict()
    for letter in boxId:
        if dictCount.__contains__(letter):
            dictCount[letter]+=1
        else:
            dictCount[letter] = 1
    return set(dictCount.values())

def checksum(texts:list):
    two = 0
    three = 0
    for boxId in texts:
        count = count_letters(boxId)
        if 2 in count: two+=1
        if 3 in count: three+=1

    return two * three


if __name__ == '__main__':
    boxIdsTest = [
        "abcdef",
        "bababc",
        "abbcde",
        "abcccd",
        "aabcdd",
        "abcdee",
        "ababab"
        ]
    assert checksum(boxIdsTest) == 12
    
    boxIds = []
    with open('./input.txt') as file:
        for box in file:
            boxIds.append(box.strip())
    print(checksum(boxIds))
        