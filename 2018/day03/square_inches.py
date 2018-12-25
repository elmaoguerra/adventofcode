class Claim:
    def __init__(self, id, left, top, width, height):
        self.id = id
        self.left = left
        self.top = top
        self.width = width
        self.height = height


def get_size(claims: list):
    x = 0
    y = 0
    for c in claims:
        cx = c.left + c.width
        cy = c.top + c.height

        if(cx > x):
            x = cx
        if(cy > y):
            y = cy

    return (x, y)


def fill_fabric(fabric: list, claims: list):
    x = set()
    clean_claims = set()

    for c in claims:
        cy = c.top
        clean_claims.add(str(c.id))
        for i in range(c.height):
            row = cy + i
            cx = c.left
            for j in range(c.width):
                col = cx + j
                if fabric[row][col] != '.':
                    x.add('{},{}'.format(row, col))
                    current = fabric[row][col]
                    new = str(c.id)
                    if(clean_claims.__contains__(current)):
                        clean_claims.remove(current)
                    if(clean_claims.__contains__(new)):
                        clean_claims.remove(new)

                fabric[row][col] = str(c.id)

    return len(x), clean_claims


# claims = [
#     Claim(1, 1, 3, 4, 4),
#     Claim(2, 3, 1, 4, 4),
#     Claim(3, 5, 5, 2, 2),
# ]

# size = get_size(claims)

# fabric = [['.' for i in range(size[0])] for i in range(size[1])]


# x, completed = fill_fabric(fabric, claims)
# assert x == 4
# assert completed == {'3'}


claims = []
with open('./input.txt') as file:
    for line in file:

        line = line.replace(' @', '').replace('#', '').replace(':', '').strip()

        id, buondries, size = line.split(' ')

        left, top = buondries.split(',')
        width, height = size.split('x')

        claims.append(Claim(id, int(left), int(top), int(width), int(height)))

size = get_size(claims)
fabric = [['.' for i in range(size[0])] for i in range(size[1])]
x, completed = fill_fabric(fabric, claims)

print(x)
print(completed)
