import random

# Class that implements the Fisher-Yates-Durstenfeld algorithm for randomly shuffling a list
class Shuffler:

    def Shuffle(self, data):
        n = len(data)
        while n > 1:
            n -= 1
            item = random.randint(0, n)
            temp = data[item]
            data[item] = data[n]
            data[n] = temp

def CreateShuffler():
    return Shuffler()

            
            
