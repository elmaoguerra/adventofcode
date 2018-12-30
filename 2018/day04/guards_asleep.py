import re
from datetime import datetime


class Record:
    def __init__(self, str_time, description):
        self.date = datetime.strptime(str_time, "%Y-%m-%d %H:%M")
        self.description = description

    def __repr__(self):
        return "[{}] {}\n".format(self.date, self.description)


class Guard:
    def __init__(self, id):
        self.id = id
        self.minutes = [0 for i in range(60)]

    def update_sleep_time(self, start, stop):
        for i in range(start, stop):
            self.minutes[i] += 1

        return sum(self.minutes), self.common_minute()

    def common_minute(self):
        maximum = max(self.minutes)
        common_minute = self.minutes.index(maximum)
        return maximum, common_minute

    def __repr__(self):
        id = self.id
        total = sum(self.minutes)
        common_minute = self.common_minute()
        return "id = {0}, Total = {1}, Code= Id({0}) * Common Minute({2}) = {3}".format(
            id, total, common_minute[1], (id*common_minute[1]))


def process_records(records: list):
    records.sort(key=lambda r: r.date)
    id = 0
    sleep_time = datetime.now()
    guards = dict()
    guard_that_sleeps_most = None
    guard_same_minute = None
    sum_asleep = 0
    count_same_minute = 0
    for r in records:
        match = re.search(r'#(\d*)', r.description)

        if not guards.__contains__(id) and id > 0:
            guards[id] = Guard(id)

        if match:
            id = int(match.group(1))
        else:
            if r.description == "falls asleep":
                sleep_time = r.date
            elif r.description == "wakes up":
                start = sleep_time.minute
                stop = r.date.minute
                asleep, common_minute = guards[id].update_sleep_time(
                    start, stop)
                count = common_minute[0]
                if asleep > sum_asleep:
                    sum_asleep = asleep
                    guard_that_sleeps_most = guards[id]

                if count > count_same_minute:
                    count_same_minute = count
                    guard_same_minute = guards[id]

    return guard_that_sleeps_most, guard_same_minute


records = []
with open('./input.txt') as file:
    for line in file:
        match = re.search(r'\[(.*?)\] (.*)', line.strip())
        date, description = match.groups()
        records.append(Record(date, description))

print(process_records(records))
